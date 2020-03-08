using System.Windows;

namespace Chat_Chan
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public string message;

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

        #endregion

        public string ConvertErrorCodeMessage(int errorCode)
        {
            switch (errorCode)
            {
                case 400:
                    return "400 - 権限がありません";
                case 401:
                    return "401 - 接続ユーザー数が上限に達しています";
                case 402:
                    return "402 - サーバーが起動していません";
                case 418:
                    return "418 - I'm a P2PDevelop";
                default:
                    return null;
            }
        }

        private void BtnChatSend_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}