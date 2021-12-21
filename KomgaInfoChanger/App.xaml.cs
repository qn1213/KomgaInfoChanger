using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace KomgaInfoChanger
{
    /// <summary>
    /// App.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class App : Application
    {
        private void ApplicationStart(object sender, StartupEventArgs e)
        {
            //Window login = new LoginWindow();
            //login.Show();

            //RestAPI.ApiSender.Send();

            Dictionary<string,string> headers = new Dictionary<string,string>();
            headers.Add("Authorization", "");
            string res = RestAPI.ApiSender.Request<string>(Method.GET, "주소!", "에피아이 경로!", headers);

            JObject obj = JObject.Parse(res);

            string status = obj.GetValue("status").ToString();
            string error = obj.GetValue("error").ToString();
            string message = obj.GetValue("message").ToString();
        }
    }
}
