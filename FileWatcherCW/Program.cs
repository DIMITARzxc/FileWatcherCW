using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileWatcherCW
{
    class FileWatcher
    {
        public FileWatcher()
        {

        }
        public void Start()
        {
            while (true)
            {

            }
        }
        public event EventHandler Check;
    }
    class Program
    {
        static void Main(string[] args)
        {
            FileWatcher w = new FileWatcher();
            w.Check += W_Check;
        }

        private static void W_Check(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
