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
    /// チャット・コマンド・状態確認の送受信に使うポート
    /// </summary>
    public enum Ports : int
    {
        Message = 37564,
        Command = 46573,
        Status = 41410
    }

    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public string message;
        public string chatmessage;

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
            tbMessage.Text = message;
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

        public string ConvertErrorCodeMessage(int errorCode)
        {
            switch (errorCode)
            {
                case 400:
                    return "400 - 権限がありません";
                case 401:
                    return "401 - 接続ユーザー数が上限に達しています";
                case 500:
                    return "500 - サーバーが起動していません";
                case 418:
                    return "418 - I'm a P2PDevelop";
                default:
                    return null;
            }
        }

        public void DeSelializeJson()
        {

        }
    }
}