namespace FTPEnable
{
    /// <summary>
    /// Class to hold and parse commandline arguments.
    /// </summary>
    class Params
    {
        private static string User { get; set; }
        private static string Pass { get; set; }
        private static string Addr { get; set; }
        private static string Drive { get; set; }

        private static string Username 
        { get 
            { 
                if (User != "") { return " /user:"; ; }
                return "";
            }
        }

        private static string[] Options 
        { get 
            { return new string[] { $"{Drive}: /delete", $"{Drive}: {Addr}/{Pass}{Username}{User} /hide" }; }
        }

        /// <summary>
        /// Parses the command line arguments and returns a string[] array.
        /// </summary>
        /// <param name="args">Excpects a string array. Commandline Arguments works. Will append Help options if blank.</param>
        /// <returns></returns>
        public static string[] ParseArgs(string[] args)
        {
            if (args.Length == 0) { args = new string[] { "/h" }; }

            for (var Index = 0; args.Length > Index || args.Length == 0; Index++)
            {
                switch (args[Index].ToLower())
                {
                    case "/u":
                    case "/user":
                    case "-u":
                    case "-user":
                        User = $"{args[Index + 1]}";
                        break;
                    case "/p":
                    case "/pass":
                    case "-p":
                    case "-pass":
                        Pass = " " + args[Index + 1];
                        break;
                    case "/i":
                    case "/ip":
                    case "-i":
                    case "-ip":
                        Addr = args[Index + 1];
                        break;
                    case "/d":
                    case "/drive":
                    case "-d":
                    case "-drive":
                        Drive = args[Index + 1];
                        break;
                    case "/h":
                    case "/help":
                    case "-h":
                    case "-help":
                    case "/?":
                    case "-?":
                        Program.Help();
                        break;
                    default:
                        break;
                }
            }
            return Options;
        }
    }
}
