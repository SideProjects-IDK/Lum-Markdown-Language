using static lum.utils.log;
using static lum.utils.files;

namespace lum
{
    internal class Program
    {
        public static bool IsHintAllowed = true;
        public static bool IsErrorAllowed = true;
        public static bool IsInfoAllowed = true;
        public static bool IsLoggingAllowed = true;


        public static bool IsUpdatingAllowed = true;

        public static string __Version__ = "0.0.1";

        static void Main(string[] args)
        {
            if (args.Length <= 0)
            {
                out_custom("Fatal:", ConsoleColor.Red, "No input file provided.");
                hint("type `-h` for help.");
                return;
            }

            if (args[0].ToLower() == "-h")
            {
                List<string> HelpText = new List<string>
                    {
                        "type `-h` for this help message.",
                        "type `-conf-env` to configure your pc envoirnment. (do this only one time)",
                        "type `-new $project_name` to create a new project in current directory.",
                        "type `-compile` or `-c` to compile your lmark files into html.",
                        "type `-build` to build your project. (ready to be hosted on a web-server)",
                    };

                foreach (string item in HelpText)
                {
                    hint(item);
                }
            }
            else if (args[0].ToLower() == "-conf-env")
                createEnv.EnvFiles();
            else if (args[0].ToLower() == "-new")
            {
                if (args.Length < 2)
                {
                    out_custom("Fatal:", ConsoleColor.Red, "No project name provided.");
                    hint("type `-h` for help.");
                    return;
                }
            }
        }
    }
}
