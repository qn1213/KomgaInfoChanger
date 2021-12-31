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
            //env.logger.AddLog();
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
                    files.Add(file.FullName);
            }

            Dictionary<string, SMetaDataAttribute> myFile = ArchiveLoader.GetInfoFromFile(files.ToArray());

            // 서버 데이터와 클라이언트 데이터 비교 후 바디 데이터 생성
            string body = null;
            BodyDataMaker.MakeMultipleBody(ref myFile, ref body);

            //List<string> bodyData = new List<string>();
            //BodyDataMaker.MakeBody(ref myFile, ref bodyData);
            // API 호출
            Protocols.ReqPatchBooksMeta req2 = new Protocols.ReqPatchBooksMeta();
            req2.Request(body);



            // 사용했던 변수들 초기화

#else

#endif
        }
    }
}
