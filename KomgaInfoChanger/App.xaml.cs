#define DEBUG

using System.Windows;
using System.Collections.Concurrent;
using System.Collections.Generic;
namespace KomgaInfoChanger
{
    public partial class App : Application
    {
        private void ApplicationStart(object sender, StartupEventArgs e)
        {
#if DEBUG
            Logger log = Logger.GetInstance;
            env.Init();


            Helper.SetServerInfo();

            // 로그인 정보 겟
            Protocols.ReqSetCookie req = new Protocols.ReqSetCookie();
            if (!req.Request())
                return;

            // 서버의 북 정보 겟
            Protocols.ReqBooksInfo reqBook = new Protocols.ReqBooksInfo(9999);
            env.bookInfo = reqBook.Request();
            if (env.bookInfo.Count == 0)
                return;

            // 클라이언트 파일 겟 한다음 배열로 처리
            string folderPath = @"C:\SMB\TestFile";
            System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(folderPath);

            List<string> files = new List<string>();
            foreach(System.IO.FileInfo file in di.GetFiles())
            {
                if (file.Extension.ToLower().CompareTo(".zip") == 0)
                { 
                    files.Add(file.FullName);
                }
            }

            Dictionary<string, SMetaDataAttribute> myFile = ArchiveLoader.GetInfoFromFile(files.ToArray());

            // 서버 데이터와 클라이언트 데이터 비교 후 바디 데이터 생성

            // API 호출
            
            // 사용했던 변수들 초기화




            //Protocols.ReqPatchBooksMeta reqPatch = new Protocols.ReqPatchBooksMeta();
            //reqPatch.Request("{\"076YPGEHQCH4F\":{\"tags\":[\"tags1\",\"tag2\"],\"authors\":[{\"role\":\"Lang\",\"name\":\"Korean\"},{\"role\":\"number\",\"name\":\"9999\"},{\"role\":\"type\",\"name\":\"test\"},{\"role\":\"role1\",\"name\":\"na1\"},{\"role\":\"role2\",\"name\":\"na2\"}]}}");
            

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
