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
using System.Windows.Shapes;
using KomgaInfoChanger.UI;

namespace KomgaInfoChanger
{
    /// <summary>
    /// LoginWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class LoginWindow : Window
    {
        //SolidColorBrush color_textfield_Error = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFF08585"));
        SolidColorBrush color_textfield_Error = UiUtils.BrushFromColorCode("#FFF08585");
        SolidColorBrush color_textfield_Normal = UiUtils.BrushFromColorCode("#FFFFFFFF");

        //ui default values
        string tbx_default_addr;
        string tbX_default_account;
        string tbx_default_password;
        Brush color_tbxBackground_default;
        double color_tbxOpacity_default;

        public LoginWindow()
        {
            InitializeComponent();
            CreateButton(null,null, "test");
        }
        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
            tbx_default_addr = xn_serverAddr.Text;
            tbX_default_account = xn_serverID.Text;
            tbx_default_password = xn_serverPW.Password;
            color_tbxBackground_default = xn_serverAddr.Background;
            color_tbxOpacity_default = xn_serverAddr.Opacity;
        }

            private void ClickLoginButton(object sender, RoutedEventArgs e)
        {
            string protocol = "http://";
            if (xn_protocolToggleButton.IsChecked ?? false)
            {
                protocol = "https://";
            }
            if (!IsLoginTextboxEmpty())
            {
                bool isLoginSuccess = Helper.SetServerInfo(protocol + xn_serverAddr.Text, xn_serverID.Text, xn_serverPW.Password, xn_saveCheck.IsChecked);

                if (isLoginSuccess)
                {
                    this.Close();
                }
            }
            
        }
        private void ClickTestDataLoad(object sender, RoutedEventArgs e)
        {
            Helper.ReadServerInfo();
        }

        
        private bool IsLoginTextboxEmpty()
        {
            bool fullWritten = false;
            if (string.IsNullOrEmpty(xn_serverAddr.Text) || xn_serverAddr.Text == tbx_default_addr )
            {
                xn_serverAddr.Background = color_textfield_Error;
                fullWritten = true;
            }
            if (string.IsNullOrEmpty(xn_serverID.Text) || xn_serverID.Text == tbX_default_account )
            {
                xn_serverID.Background = color_textfield_Error;
                fullWritten = true;
            }
            if (string.IsNullOrEmpty(xn_serverPW.Password) || xn_serverPW.Password == tbx_default_password )
            {
                xn_serverPW.Background = color_textfield_Error;
                fullWritten = true;
            }

            return fullWritten;
        }
        
        private Button CreateButton(string Name = null, string Tag = null, string Content = null, Double Width = 75, Double Height = 70)
        {
            // 버튼 생성
            Button btn = new Button();   // 버튼 생성
            btn.Name = Name;   // 버튼명

            // 버튼 생성 - 모양및 색상
            btn.Content = Content;   // 버튼 Content
            //btn.Tag = Tag;   // tag
            btn.Height = Height;   // 세로길이
            //btn.Width = Width;   // 가로길이

            /* // 버튼 색상
            btn.Background = new SolidColorBrush(Color.FromArgb(255, 0, 80, 80));   // 배경
            btn.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));   // 글씨색
            */

            // 버튼 생성 - 이벤트 등록
            btn.Click += (s, e) =>
            {
                // 
            };

            /* // 버튼 생성 - 위치
            btn.HorizontalAlignment = HorizontalAlignment.Left;   // 정렬 기준 좌측
            btn.VerticalAlignment = VerticalAlignment.Top;   // 정렬 기준 상측
            btn.Margin = new Thickness(btn.Width * (i % 10), btn.Height * (i / 10), 0, 0);   // 위치
            grid1.Children.Add(btn);   // grid1 에 넣기
            */
            btn.VerticalAlignment = VerticalAlignment.Top;
            btn.Margin = new Thickness(0);
            //xn_stackPanel1.Children.Add(btn);
            return btn;
        }




        private void xn_serverAddr_TextChanged(object sender, TextChangedEventArgs e)
        {
            xn_serverAddr.Background = color_tbxBackground_default;
            xn_serverAddr.Foreground = Brushes.White;
            xn_serverAddr.Opacity = 1;
        }
        private void xn_serverID_TextChanged(object sender, TextChangedEventArgs e)
        {
            xn_serverID.Background = color_tbxBackground_default;
            xn_serverID.Opacity = 1;
        }
        private void xn_serverPW_PasswordChanged(object sender, RoutedEventArgs e)
        {
            xn_serverPW.Background = color_tbxBackground_default;
            xn_serverPW.Opacity = 1;
        }


        private void xn_serverAddr_GotFocus(object sender, RoutedEventArgs e)
        {
            if (xn_serverAddr.Text.Equals(tbx_default_addr))
            {
                xn_serverAddr.Clear();
            }
        }
        private void xn_serverID_GotFocus(object sender, RoutedEventArgs e)
        {
            if (xn_serverID.Text.Equals(tbX_default_account))
            {
                xn_serverID.Clear();
            }
        }
        private void xn_serverPW_GotFocus(object sender, RoutedEventArgs e)
        {
            if (xn_serverPW.Password.Equals(tbx_default_password))
            {
                xn_serverPW.Clear();
            }
        }


        private void xn_serverAddr_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(xn_serverAddr.Text))
            {
                xn_serverAddr.Text = tbx_default_addr;
                xn_serverAddr.Opacity = color_tbxOpacity_default;
            }
        }
        private void xn_serverID_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(xn_serverID.Text))
            {
                xn_serverID.Text = tbX_default_account;
                xn_serverID.Opacity = color_tbxOpacity_default;
            }
        }
        private void xn_serverPW_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(xn_serverPW.Password))
            {
                xn_serverPW.Password = tbx_default_password;
                xn_serverPW.Opacity = color_tbxOpacity_default;
            }
        }



        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }


    }


}
