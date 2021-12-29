#define DEBUG

using System.Windows;
using System.Collections.Concurrent;
using System;

namespace KomgaInfoChanger
{
    public partial class App : Application
    {
        private void ApplicationStart(object sender, StartupEventArgs e)
        {
#if DEBUG
            Logger log = Logger.GetInstance;
            System.Console.WriteLine(env.myDocumentsPath);
            //Helper.SetServerInfo(); // 내문서에 acc.txt 파일 생성 후
            // 1. 서버 주소
            // 2. 아이디
            // 3. 비밀번호 순으로 적으면됨

            //Protocols.ReqSetCookie req = new Protocols.ReqSetCookie();
            
            //Protocols.ReqPatchBooksMeta reqPatch = new Protocols.ReqPatchBooksMeta();
            //reqPatch.Request("{\"076YPGEHQCH4F\":{\"tags\":[\"tags1\",\"tag2\"],\"authors\":[{\"role\":\"Lang\",\"name\":\"Korean\"},{\"role\":\"number\",\"name\":\"9999\"},{\"role\":\"type\",\"name\":\"test\"},{\"role\":\"role1\",\"name\":\"na1\"},{\"role\":\"role2\",\"name\":\"na2\"}]}}");


            Window mainwindow = new MainWindow();
            mainwindow.Show();
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


            //ArchiveLoader loader = new ArchiveLoader();
            //SMetaDataAttribute temp = loader.GetInfoFromFile(@"C:\SMB\test.zip");
            ////string authors = string.Join(",", temp.authors);
            ////string tags = string.Join (",", temp.tags);

            //log.AddLog(temp.number + ", " + temp.title + ", " + authors + ", " + tags);
            
#else



            Window login = new LoginWindow();
            login.Show();

            RestAPI.ApiSender.Send();
#endif
        }
    }
}
