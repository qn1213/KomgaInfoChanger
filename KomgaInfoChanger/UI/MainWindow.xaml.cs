using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using RestSharp;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace KomgaInfoChanger
{

    public partial class MainWindow : Window
    {
        public LoginWindow loginWindow = new LoginWindow();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void LoginButtonClick(object sender, RoutedEventArgs e)
        {
            if (!loginWindow.IsLoaded)
            {
                loginWindow = new LoginWindow();
                loginWindow.Show();
                
            }
            else
            {
                loginWindow.Activate();
            }

            

        }

        private void ClickLoadLoginData(object sender, RoutedEventArgs e)
        {
            Helper.ReadServerInfo();
        }

        public void SetColorLoginStatusLamp(Color _color)
        {
            LoginStatusLamp.Fill = new SolidColorBrush(_color);
        }
    }
}
