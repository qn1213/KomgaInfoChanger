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
            
            //LoadingWindow loadingWindow = new LoadingWindow();
            //loadingWindow.Show();

            Loaded += Window_Loaded;
            //this.mediaElement.MediaEnded += mediaElement_MediaEnded;
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
            //LoginStatusLamp.Fill = new SolidColorBrush(_color);
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }


        #region 윈도우 로드시 처리하기 - Window_Loaded(sender, e) 
        /// <summary>
        /// 윈도우 로드시 처리하기
        /// </summary>
        /// <param name="sender">이벤트 발생자</param> ///
        /// <param name="e">이벤트 인자</param> 
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("Resources/Spin.gif", UriKind.RelativeOrAbsolute);
            //this.mediaElement.Source = uri;
            //this.mediaElement.Play();
        }
        #endregion

        #region 미디어 엘리먼트 미디어 종료시 처리하기 - mediaElement_MediaEnded(sender, e) 
        /// <summary>
        /// 미디어 엘리먼트 미디어 종료시 처리하기
        /// </summary>
        /// <param name="sender">이벤트 발생자</param>
        /// <param name="e">이벤트 인자</param>
        private void mediaElement_MediaEnded(object sender, RoutedEventArgs e)
        {
            //this.mediaElement.Position = new TimeSpan(0, 0, 1); this.mediaElement.Play();
        }
        #endregion

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

    }
}
