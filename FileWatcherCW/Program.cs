using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FileWatcherCW
{
    class FileWatcher
    {
        private object _lock;
        private string _path;
        public DateTime lastTime;
        public DateTime checkTime;
        public FileWatcher(string path)
        {
            _path = path;
            lastTime = File.GetLastWriteTime(_path);
        }
        public void Start()
        {

            while (true)
            {

                checkTime = File.GetLastWriteTime(_path);

                if (lastTime != checkTime)
                {
                    lastTime = File.GetLastWriteTime(_path);
                    Task.Run(() => Check?.Invoke());
                }
            }
        }
        public event Action Check;

    }
    class Program
    {
        private static object _lock = new object();
        static void Main(string[] args)
        {
            File.Create("1.txt").Dispose();
            FileWatcher w = new FileWatcher("1.txt");
            w.Check += Check;
            Task.Run(() => w.Start());


            while (true)
            {
                lock (_lock)
                {
                    Console.WriteLine("Do u wanna change ur text file: 1.txt");
                }
                    var res = Console.ReadLine();
                
                if (res == "yes")
                {

                    lock (_lock)
                    {
                        File.WriteAllText("1.txt", "1");
                    }
                }
                Console.WriteLine("Wait...");
            }
        }

        private static void Check()
        {

           

            lock (_lock)
            {
                string contains = File.ReadAllText("1.txt");
                if (contains == "1")
                {

                    File.WriteAllText("1.txt", "0");
                    Thread.Sleep(10000);
                    Console.WriteLine("Correct operation, '0' in 1.txt");


                }
            }
        }
    }
}

