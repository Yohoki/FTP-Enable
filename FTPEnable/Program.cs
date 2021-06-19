using System;
using System.Diagnostics;
using System.IO;

namespace FTPEnable
{
    class Program
    {
        const bool Debug = false;
        const string FTPUse = @"C:\Program Files\Ferro Software\FTPUse\FtpUse.exe";

        static void Main(string[] args)
        {
            if (Debug != true) 
            {
                CheckInstall(FTPUse);
            }

            string[] options = Params.ParseArgs(args);
            
            if (Debug == true)
            {
                DebugText(options);
            }
            
            if (Debug != true)
            {
                Launch(options);
            }

        }

        public static void Help()
        {
            Console.WriteLine("This program is a quick loader for Ferro Software's FTPUse.exe software. It will quickly load the\n" +
                              "parameters into FTPUse via commandline, and can be run as administrator. To use this program, create\n" +
                              "a shortcut and add parameters as commandline arguments in the target field.\n\n" +
                              "Usage:\n\n" +
                              "\t'/user Username'(Optional)\n" +
                              "\t\tSpecifies the username.Leave blank for anonymous. (or maybe type aononymous ?)\n" +
                              "\t'/Pass Password'(Optional)\n" +
                              "\t\tSpecifies the password.Leave blank if no password is required.\n" +
                              "\t'/IP IPAddress'(Required)\n" +
                              "\t\tSpecifies the remote host's IP address.\n" +
                              "\t'/Drive DriveLetter'(Required)\n" +
                              "\t\tSpecify a single character for the drive letter.\n" +
                              "\t'/Help'(Optional)\n" +
                              "\t\tDisplays this help text.\n\n" +
                              "Press enter key to exit...");
            Console.ReadLine();
            System.Environment.Exit(0);
        }

        private static void CheckInstall(string FTPUse)
        {
            if (!File.Exists(FTPUse))
            {
                Console.WriteLine("\n\n\t\tFerro Software's FTPUse.exe not found!\n" +
                                  "\t\tPlease install FTPUse to Program Files\n\n");
                Help();
            }
        }

        private static void DebugText(string[] options)
        {
            Console.WriteLine(options[0] + "\n" + options[1]); Console.ReadLine();
        }

        private static void Launch(string[] options)
        {
            Process StartFTPUse = new Process();

            foreach (string option in options)
            {
                StartFTPUse.StartInfo.FileName = FTPUse;
                StartFTPUse.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                StartFTPUse.StartInfo.UseShellExecute = true;
                StartFTPUse.StartInfo.Verb = "runas";
                StartFTPUse.StartInfo.Arguments = option;
                StartFTPUse.Start();
            }
        }
    }
}
