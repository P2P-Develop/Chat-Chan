using System;
using System.Net.Sockets;
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

            }
        }

        #endregion

        public string ConvertCodeMessage(int code)
        {
            switch (code)
            {
                case 200:
                    return "200 - 接続できます";
                case 400:
                    return "400 - 権限がありません";
                case 401:
                    return "401 - 接続ユーザー数が上限に達しています";
                case 418:
                    return "418 - I'm a P2PDevelop";
                case 500:
                    return "500 - サーバーが起動していません";
                default:
                    return "不明のエラーが発生しました";
            }
        }

        public void DeSelializeJson()
        {

        }

        public async void Connect(string user)
        {
            if (tbSessionName.Text.StartsWith(" "))
            {
                tbSessionError.Text = "セッション名が無効です";
                return;
            }

            btnSessionStart.IsEnabled = false;
            tbSessionName.IsEnabled = false;

            await Task.Run(() =>
            {
                try
                {

                    using (TcpClient tcp = new TcpClient(tbSessionName.Text, 41410))
                    {
                        tbConsole.Visibility = Visibility.Visible;
                        tbConsole.Clear();
                        tbConsole.AppendText("[NET]TCP Client Started to " + tbSessionName.Text + ".");

                    }
                }
                catch (Exception ex)
                {
                    tbSessionError.Text = ex.Message;
                }
            });

        }
    }
}