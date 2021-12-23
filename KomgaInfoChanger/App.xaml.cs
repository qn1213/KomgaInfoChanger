#define DEBUG

using System.Windows;
using System.Collections.Concurrent;
namespace KomgaInfoChanger
{
    public partial class App : Application
    {
        private void ApplicationStart(object sender, StartupEventArgs e)
        {
#if DEBUG
            Logger log = Logger.GetInstance;

            env.info.serverAddr = "https://naver.com";
            env.info.serverID = "1234@naver.com";
            env.info.serverPW = "1234";

            Protocols.ReqSetCookie req = new Protocols.ReqSetCookie();

            if(!req.Request())
                log.AddLog(req.res.status + " : " + req.res.error + " :" + req.res.message);
            else
                log.AddLog("로그인 성공");

            Protocols.ReqBooksInfo req2 = new Protocols.ReqBooksInfo();
            ConcurrentDictionary<string, Infos.SAttribute> tmp = req2.Request();

#else
            Window login = new LoginWindow();
            login.Show();

            RestAPI.ApiSender.Send();
#endif
        }
    }
}
