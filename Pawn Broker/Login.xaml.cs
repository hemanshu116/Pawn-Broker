using System.Windows;
using System.Windows.Input;
using MaterialDesignThemes.Wpf;
using Pawn_Broker.constants;
using Pawn_Broker.db.dataManagers;
using Pawn_Broker.db.helpers;
using Pawn_Broker.db.models;
using Pawn_Broker.Views;

namespace Pawn_Broker
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Login : Window
    {
        private readonly CustomMessage _message = new CustomMessage();
        public Login()
        {
            InitializeComponent();
        }

        private void Close_Icon_click(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private async void  login_button_click(object sender, RoutedEventArgs e)
        {
            if (TxtUsername.Text == "")
            {
                _message.Message.Text = "Please Enter Username";
                TxtUsername.Focus();
                await DialogHost.Show(_message, "RootDialog");
                return;
            }
            if (TxtPassword.Password == "")
            {
                _message.Message.Text = "Please Enter Password";
                TxtPassword.Focus();
                await DialogHost.Show(_message, "RootDialog");
                return;
            }
            UserDataManager userManager = new UserDataManager();
            User user = userManager.AuthenticateUser(TxtUsername.Text,TxtPassword.Password);
            if (user == null)
            {
                _message.Message.Text = "Wrong username or password";
                TxtUsername.Focus();
                await DialogHost.Show(_message, "RootDialog");
                return;
            }
            MainWindow window = new MainWindow();
            window.Show();
            Close();
        }

        private void AppLauncher_OnLoaded(object sender, RoutedEventArgs e)
        {
            PawnBrokerHelper.GetInstance().DatabaseCreate();
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }
    }
}