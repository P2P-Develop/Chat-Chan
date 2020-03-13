using System;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Chat_Chan
{
    /// <summary>
    /// メッセージをチャットとして送信するかコンソールとして送信するか
    /// </summary>
    public enum SendMode : byte
    {
        Message = 0,
        Chat = 1
    }

    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public string Message { get; set; }
        public string Chatmessage { get; set; }

        #region Constructor

        /// <summary>
        /// <see cref="MainWindow"/>のコンストラクタ
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }

        #endregion

        #region Event Handlers

        private void BtnSend_Click(object sender, RoutedEventArgs e)
        {
            tbMessage.Text = Message;
            tbMessage.Clear();
        }

        private void BtnSessionStart_Click(object sender, RoutedEventArgs e)
        {
            Connect(tbNickName.Text, tbSessionName.Text);
        }

        private void BtnEndSession_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnSettings_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnChatSend_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TbSession_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                tbMessage.Focus();
            }
        }

        private void TbMessage_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                // Send();
            }
        }

        #endregion

        /// <summary>
        /// Codeをメッセージ付きで<see cref="string"/>として返す。
        /// </summary>
        /// <param name="code">メッセージを付けるCode</param>
        /// <returns></returns>
        public static string ConvertCodeMessage(int code)
        {
            switch (code)
            {
                case 200:
                    return "200 - 接続できます";
                case 400:
                    return "400 - 権限がありません";
                case 401:
                    return "401 - 接続ユーザー数が上限に達しています";
                case 402:
                    return "402 - ユーザー名が重複しています";
                case 418:
                    return "418 - I'm a P2PDevelop";
                case 500:
                    return "500 - サーバーが起動していません";
                default:
                    return "不明のエラーが発生しました";
            }
        }

        public static void DeSelializeJson()
        {

        }

        /// <summary>
        /// <see cref="tbSessionName"/>に入力されたホストに接続しJsonファイルで状態確認をする。
        /// </summary>
        /// <param name="user">Json送信に扱うユーザー名</param>
        /// <param name="session">接続先セッション名</param>
        public async void Connect(string user, string session)
        {
            Dispatcher.Invoke(() =>
            {
                // tbSessionNameの最初の文字がスペースの場合はエラーを起こす
                if (tbSessionName.Text.StartsWith(" ") || tbSessionName.Text.StartsWith("　"))
                {
                    tbSessionError.Text = "セッション名が無効です";
                    return;
                }

                // バグ予防
                btnSessionStart.IsEnabled = false;
                tbSessionName.IsEnabled = false;
            });

            // 非同期処理で接続する
            await Task.Run(() =>
            {
                try
                {
                    // Call-PortにTCPクライアントでCallする
                    using (TcpClient tcp = new TcpClient(session, 41410))
                    {
                        // データ送受信インスタンス
                        NetworkStream ns = tcp.GetStream();
                        MemoryStream ms = new MemoryStream();
                        ns.ReadTimeout = 20000;
                        ns.WriteTimeout = 15000;
                        // サーバー受信データ格納
                        object JoinServerReceive;
                        Dispatcher.Invoke(() =>
                        {
                            // ターミナル初期化
                            tbConsole.Visibility = Visibility.Visible;
                            tbConsole.Clear();
                            tbConsole.AppendText("[NET]TCP Client Started to " + tbSessionName.Text + ".");
                        });
                        // stringのJsonをbyte[]に起こす
                        byte[] _sendBytes = Encoding.UTF8.GetBytes("{ \"exec\": \"join\", \"user\": \"" + user + "\" }\r\n");
                        // NetworkStreamで送信する
                        ns.Write(_sendBytes, 0, _sendBytes.Length);
                        _sendBytes = null;
                        // 受信用のバッファーをbyte[]に起こす
                        byte[] resBytes = new byte[256];
                        int resSize = 0;
                        do
                        {
                            // データの一部を受信する
                            resSize = ns.Read(resBytes, 0, resBytes.Length);
                            // Readが0だった場合はエラーとする
                            if (resSize == 0)
                            {
                                Dispatcher.Invoke(() =>
                                {
                                    tbConsole.AppendText("[ERR]Server Closed");
                                });
                                return;
                            }
                            // 受信したデータの蓄積
                            ms.Write(resBytes, 0, resSize);
                            // まだ読み取れるかデータの最後が\r\nでない時は受信を続ける
                        } while (ns.DataAvailable || (resBytes[resSize - 2] != '\r' && resBytes[resSize - 2] != '\n'));
                        // 受信したデータを文字列に変換
                        string connectedJson = Encoding.UTF8.GetString(ms.GetBuffer(), 0, (int)ms.Length);
                        // エスケープ文字を削除
                        connectedJson = connectedJson.TrimEnd('\n');
                        connectedJson = connectedJson.TrimEnd('\r');
                        _sendBytes = Encoding.UTF8.GetBytes("{ \"exec\": \"leave\" }\r\n");
                        ns.Write(_sendBytes, 0, _sendBytes.Length);
                    }
                }
                catch (Exception ex)
                {
                    Dispatcher.Invoke(() =>
                    {
                        // エラー本文をターミナルが開いている場合でも閉じている場合でも表示されるようにする
                        if (tbConsole.Visibility == Visibility.Visible)
                        {
                            tbConsole.AppendText("\n" + ex.Message);
                        }
                        else
                        {
                            tbSessionName.IsEnabled = true;
                            btnSessionStart.IsEnabled = true;
                            tbSessionError.Text = ex.Message;
                        }
                    });
                }
            });
        }

        public static void WriteLine()
        {

        }

        public static void Write()
        {

        }
    }
}