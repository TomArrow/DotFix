using System;
using System.IO;

namespace DotFix
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] files = Directory.GetFiles(Environment.CurrentDirectory);
            Console.WriteLine(files.Length);
            foreach(string file in files)
            {
                if (file[file.Length-1] == '.')
                {
                    Console.WriteLine(file);
                    File.Move(@"\\?\"+file, @"\\?\" + file.Substring(0, file.Length - 1));
                    //break;
                }
            }
            string[] dirs = Directory.GetDirectories(Environment.CurrentDirectory);
            Console.WriteLine(dirs.Length);
            foreach(string dir in dirs)
            {
                if (dir[dir.Length-1] == '.')
                {
                    Console.WriteLine(dir);
                    Directory.Move(@"\\?\"+dir, @"\\?\" + dir.Substring(0, dir.Length - 1));
                    //break;
                }
            }
            if (Console.IsInputRedirected)
            {

                Console.WriteLine("Done. Press Enter to continue.");
                Console.Read();
            } else
            {
                Console.WriteLine("Done. Press key to continue.");
                Console.ReadKey();
            }
        }
    }
}
