using System;
using System.Text;
using System.IO;

namespace KomgaInfoChanger
{
    // 로그는 실패한 기록만 남길 것.
    internal class Logger
    {
        private static readonly Lazy<Logger> instance = new Lazy<Logger>(() => new Logger());

        private QueueFactory<string> loggers;

        private string filePath = env.logPath + Helper.GetDate() + "_InfoChangerLog.txt";

        private readonly object _fileLock = new object();

        private Logger()
        {
            if (!File.Exists(filePath))
                using (File.Create(filePath)) { }

            loggers = new QueueFactory<string>();
            loggers.DoingJob += Log;
        }

        public static Logger GetInstance
        {
            get
            {
                return instance.Value;
            }
        }

        public void AddLog(string e)
        {
            loggers.Enqueue(e);
        }

        private void Log(object sender, QueueThreadEventArgs<string> e)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("[");
            builder.Append(Helper.GetTime());
            builder.Append("] ");
            builder.Append(e.TypeArgs);
            builder.Append("\r\n");

            lock (_fileLock)
                File.AppendAllText(filePath, builder.ToString());
        }
    }
}
