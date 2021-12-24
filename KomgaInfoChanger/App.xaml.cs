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
            env.info.serverID = "a@naver.com";
            env.info.serverPW = "a!";

            //Protocols.ReqSetCookie req = new Protocols.ReqSetCookie();

            //if(!req.Request())
            //    log.AddLog(req.res.status + " : " + req.res.error + " :" + req.res.message);
            //else
            //    log.AddLog("로그인 성공");

            //Protocols.ReqBooksInfo req2 = new Protocols.ReqBooksInfo(2);
            //ConcurrentDictionary<string, SBookAttribute> tmp = req2.Request();

            //foreach(var item in tmp)
            //{
            //    log.AddLog(item.Key + " : " + item.Value.id + ", " + item.Value.seriesId + ", " + item.Value.libraryId);
            //}


            ArchiveLoader loader = new ArchiveLoader();
            SMetaDataAttribute temp = loader.GetInfoFromFile(@"C:\SMB\test.zip");
            string authors = string.Join(",", temp.authors);
            string tags = string.Join (",", temp.tags);

            log.AddLog(temp.number + ", " + temp.title + ", " + authors + ", " + tags);
            
#else



            Window login = new LoginWindow();
            login.Show();

            RestAPI.ApiSender.Send();
#endif
        }
    }
}
