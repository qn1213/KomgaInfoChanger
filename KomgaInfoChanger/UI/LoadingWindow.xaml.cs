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

namespace KomgaInfoChanger
{
    /// <summary>
    /// Loading.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class LoadingWindow : Window
    {
        public LoadingWindow()
        {
            InitializeComponent();

            Loaded += Window_Loaded;
            this.mediaElement.MediaEnded += mediaElement_MediaEnded;

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
            this.mediaElement.Source = uri;
            this.mediaElement.Play();
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
            this.mediaElement.Position = new TimeSpan(0, 0, 1); this.mediaElement.Play();
        }
        #endregion

    }
}
