using System;
using System.Threading.Tasks;
using System.IO;
using FluentFTP;

namespace FtpWatcher
{
    class Program : IProgress<FtpProgress>
    {
        static void Main(string[] args)
        {
            //FtpUpload(@"R:\mydb.db", path => {
            //    Console.WriteLine(path);
            
            FileSystemWatcher watcher = new FileSystemWatcher(@"C:\FTP");
            watcher.Created += Watcher_Created;
            watcher.EnableRaisingEvents = true;
            Console.WriteLine("FILE WATCH =>" + watcher.Path);
            
            Console.ReadLine();
        }

        private async static void Watcher_Created(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine("UPLOAD START DETECTED " + e.FullPath);
            await WaitUploaded(e.FullPath, TimeSpan.FromHours(1));
            Console.WriteLine("UPLOAD FINISHED DETECTED " + e.FullPath);


            Console.WriteLine("FTP UPLOAD 2nd SERVER " + e.FullPath);
            await FtpUpload(e.FullPath, path => {

                File.Delete(e.FullPath);
                Console.WriteLine(path + "파일을 지웁니다.");

            });
        }

        public static async Task FtpUpload(string path, Action<string> OnCompleted)
        {
            try
            {
                var HostName = "127.0.0.1";
                var UserName = "user";
                var PortNumber = 21;
                var Password = "????";

                FtpClient ftpClient = new FtpClient(HostName, PortNumber, UserName, Password);
                await ftpClient.ConnectAsync();
                
                var status = await ftpClient.UploadFileAsync(path, @"/HDD1/DOWNLOAD/" + Path.GetFileName(path), FtpRemoteExists.Overwrite, progress: new Program());

                if (status.IsSuccess())
                {
                    OnCompleted?.Invoke(path);
                }
                else
                {
                    Console.WriteLine("Error");
                }
            } 
            catch (Exception e)
            {
                Console.WriteLine("Error: {0}", e);
            }
        }

        public static async Task WaitUploaded(string path, TimeSpan timeout)
        {
            var started = DateTime.Now;
            FileInfo f = new FileInfo(path);
            while (true)
            {
                if (f.IsLocked())
                {
                    await Task.Delay(1000);
                    if (started.Add(timeout) < DateTime.Now)
                    {
                        Console.WriteLine("TIMEOUT");
                        break;
                    }
                }
                else
                {
                    break;
                }
            }
        }

        public void Report(FtpProgress value)
        {
            Console.WriteLine(value.Progress + "%");
        }
    }

    public static class FileWatcherHelper
    {
        public static bool IsLocked(this FileInfo f)
        {
            try
            {
                string fpath = f.FullName;
                FileStream fs = File.OpenWrite(fpath);
                fs.Close();
                return false;
            }
            catch (Exception) { return true; }
        }
    }
}
