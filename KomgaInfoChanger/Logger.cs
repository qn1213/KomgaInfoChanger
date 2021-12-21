using System;
using System.IO;

namespace KomgaInfoChanger
{
    internal class Logger
    {
        private QueueFactory<string> loggers;        

        public Logger()
        {
            // 호출 후 로그 파일 생성(날짜별)
            if(!File.Exists(env.logPath))
            {
                using(File.Create(env.logPath)){}
            }

            loggers = new QueueFactory<string>();
            loggers.DoingJob += Log;
        }

        public void AddLog(object sender, string e)
        {
            loggers.Enqueue(e);
        }

        private void Log(object sender, QueueThreadEventArgs<string> e)
        {            
            try
            {
                StreamWriter writer = null;
                writer = File.AppendText(env.logPath);
                writer.WriteLine(e);
                writer.Close();
            }
            catch (Exception)
            {
                loggers.Stop(); // 여기까지 오면 우짜지... 방법 제안좀요 ㅠ
            }
        }
    }
}
