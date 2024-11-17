using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;

using static lum.Program;

namespace lum.utils
{
    public class log
    {
        public static bool hint(string message)
        {
            if (!IsLoggingAllowed || !IsHintAllowed)
                return false;

            out_custom(" Hint:", ConsoleColor.Yellow, message);

            return true;
        }

        public static bool error(string message)
        {
            if (!IsLoggingAllowed || !IsErrorAllowed)
                return false;

            out_custom("Error:", ConsoleColor.Red, message);

            return true;
        }

        public static bool info(string message)
        {
            if (!IsLoggingAllowed || !IsInfoAllowed)
                return false;

            out_custom("Info:",ConsoleColor.Cyan,message);

            return true;
        }

        public static bool info_transpiled(string file)
        {
            if (!IsLoggingAllowed || !IsInfoAllowed)
                return false;

            out_custom("Transpiled:", ConsoleColor.Green, file);

            return true;
        }
        public static bool info_updated_file(string file)
        {
            if (!IsLoggingAllowed || !IsInfoAllowed)
                return false;

            out_custom(" Updated:", ConsoleColor.Green, file);

            return true;
        }


        public static bool out_custom(string type, ConsoleColor color, string message)
        {
            if (!IsLoggingAllowed)
                return false;

            Console.ForegroundColor = color;
            Console.Write($"{type} ");

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(message+"\n");

            return true;
        }
    }
}
