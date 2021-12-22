#define DEBUG

using System.Windows;

namespace KomgaInfoChanger
{
    public partial class App : Application
    {
        private void ApplicationStart(object sender, StartupEventArgs e)
        {
#if DEBUG
            Logger log = Logger.GetInstance;

            env.info.serverAddr = "https://naver.com";            
            env.info.serverID = "apisendTest";
            env.info.serverPW = "2";

            Protocols.ReqSetCookie_test req = new Protocols.ReqSetCookie_test();

            if(!req.Request())
                log.AddLog(req.res.status + " : " + req.res.error + " :" + req.res.message);
            else
                log.AddLog("로그인 성공");

#else
            Window login = new LoginWindow();
            login.Show();

            RestAPI.ApiSender.Send();
#endif
        }
    }
}
