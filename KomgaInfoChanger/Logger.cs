using System;
using System.IO;

namespace KomgaInfoChanger
{
    internal class Logger
    {
        private QueueFactory<string> loggers;
        private string filePath = env.logPath + Helper.GetDate() + ".txt";

        public Logger()
        {
            if (!File.Exists(filePath))
            {
                using(File.Create(filePath)){}
            }

            loggers = new QueueFactory<string>();
            loggers.DoingJob += Log;
        }

        public void AddLog(string e)
        {
            loggers.Enqueue(e);
        }

        private void Log(object sender, QueueThreadEventArgs<string> e)
        {
            File.AppendAllText(filePath, e.TypeArgs);
        }
    }
}
