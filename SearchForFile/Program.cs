using System;
using System.IO;

namespace SearchForFile
{
    class Program
    {
        static void Main(string[] args)
        {
            GetFilePath(@args[0], @args[1]);

            WatchFile(@args[0], @args[1]);
            Console.ReadKey();
        }


        private static void GetFilePath(string dir, string fileName)
        {
            try
            {
                string[] files = Directory.GetFiles(dir, fileName, SearchOption.AllDirectories);
                foreach (string file in files)
                {
                    Console.WriteLine(file);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"File not found!\n{e.Message}");
            }

        }

        private static void WatchFile(string dir, string filename)
        {
            FileSystemWatcher watcher = new FileSystemWatcher();
            watcher.Path = dir;
            watcher.Filter = filename;

            watcher.Changed += Watcher_Changed;
            watcher.EnableRaisingEvents = true;
        }

        private static void Watcher_Changed(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine($"File: {e.FullPath} {e.ChangeType}");
        }
    }
}
