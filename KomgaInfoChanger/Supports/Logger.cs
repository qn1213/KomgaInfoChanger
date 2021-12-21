using System.Text;
using System.IO;

namespace KomgaInfoChanger
{
    // 로그는 실패한 기록만 남길 것.
    // 그외엔 자원 아까움
    internal class Logger
    {
        private QueueFactory<string> loggers;
        private StringBuilder builder;

        private string filePath = env.logPath + Helper.GetDate() + "_InfoChangerLog.txt";

        public Logger()
        {
            if (!File.Exists(filePath))
            {
                using(File.Create(filePath)){}
            }

            loggers = new QueueFactory<string>();
            loggers.DoingJob += Log;

            builder = new StringBuilder();
        }

        public void AddLog(string e)
        {            
            loggers.Enqueue(e);
        }

        private void Log(object sender, QueueThreadEventArgs<string> e)
        {
            builder.Append("[");
            builder.Append(Helper.GetTime());
            builder.Append("] ");
            builder.Append(e.TypeArgs);

            File.AppendAllText(filePath, e.TypeArgs);
        }
    }
}
