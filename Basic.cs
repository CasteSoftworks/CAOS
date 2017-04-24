using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAOS
{
    class Basic
    {
        public static string current_line = "";
        public static string command0 = "";
        public static string command1 = "";
        public static string command2 = "";
        public static string command3 = "";
        public static string command4 = "";
        public static string command5 = "";
        public static string command6 = "";
        public static string command7 = "";
        public static string command8 = "";
        public static string command9 = "";
        public static string command10 = "";

        public static void init()
        {
            Console.Clear();
            Console.WriteLine("###############################################################################");
            Console.WriteLine("# Exit: F12                                               BASIC Version 1.0.0 #");
            Console.WriteLine("# New: F11                                   MAX 10 LINES PROGRAMS            #");
            Console.WriteLine("###############################################################################");
            
            main();
        }
        public static void main()
        {
            int line = 0;
            var input = Console.ReadLine();
            var co = input;
            var vars = "";
            if (input.ToLower().IndexOf('/') != -1)
            {
                string[] parts = input.Split('/');
                co = parts[0];
                vars = parts[1];
            }
            Console.Write(line + "");
            switch (co)
            {
                case "print":
                    command0 = vars;
                    break;
                case "goto":
                    current_line = vars;
                    if (vars == command0)
                    {
                        Console.WriteLine(command0);
                    }
                    break;
                    
                case "EXIT":
                    Console.Clear();
                    Console.WriteLine("lol");
                    return;
            }
        }
    }
}
