using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Utilities
{
    class Program
    {
        static void Main(string[] args)
        {
            //MakeTest();
            DeleteFiles(@"D:\\Log", 3);

        }


        public static void DeleteFiles(string DirPath, int Days = -3)
        {            
            string[] objSubDirectory = Directory.GetDirectories(DirPath);           
            foreach (string subdir in objSubDirectory)
            {
                var dir = new DirectoryInfo(subdir);
                if (dir.LastWriteTime <= DateTime.Now.AddDays(Days))
                {
                    dir.Delete(true);
                }
            }
        }
    }
}
