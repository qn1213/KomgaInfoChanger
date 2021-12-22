using System;
using System.Collections.Concurrent;
using System.Threading;

namespace KomgaInfoChanger
{
    internal class QueueFactory<T>
    {
        ConcurrentQueue<T> queue;
        Thread thread;

        bool isStop;
        bool isBackground;

        // 외부에서 실행할 작업
        public event EventHandler<QueueThreadEventArgs<T>> DoingJob;

        public void Stop()
        {
            isStop = true;
        }

        public int GetQueueCount()
        {
            lock (queue)
                return queue.Count;
        }

        public QueueFactory(bool isBackground = true) // 백그라운드로 돌릴건지 (기본 true)
        {
            queue = new ConcurrentQueue<T>();
            thread = new Thread(Worker);
            this.isBackground = isBackground;
        }

        private void Worker()
        {
            while (thread.IsAlive)
            {
                if (!queue.IsEmpty)
                {
                    T x = default(T);
                    bool TF = queue.TryDequeue(out x);
                    if (!TF) continue;

                    if (DoingJob == null) break;

                    if (isStop)
                    {
                        lock (queue)
                        {
                            while (queue.TryDequeue(out x)) { } // 큐 클리어하는 로직

                            isStop = false;
                            break;
                        }
                    }

                    if (DoingJob != null)
                    {
                        QueueThreadEventArgs<T> args = new QueueThreadEventArgs<T>();
                        args.TypeArgs = x;
                        DoingJob(this, args);
                    }
                }
                else
                {
                    lock (queue)
                        if (queue.Count == 0) break;
                }
            }
        }

        public void Enqueue(T obj)
        {
            queue.Enqueue(obj);

            if (!thread.IsAlive)
            {
                thread = new Thread(Worker);
                thread.IsBackground = isBackground;
                thread.Priority = ThreadPriority.BelowNormal;
                thread.Start();
            }
        }
    }

    public class QueueThreadEventArgs<T> : EventArgs
    {
        public T TypeArgs { get; set; }
    }
}