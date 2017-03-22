using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;







namespace CaOS

{

    class microtxt
    {

        public static void init()

        {
            Console.Clear();
            Console.WriteLine("###############################################################################");
            Console.WriteLine("# Exit: F12                                            Microtxt Version 1.0.0 #");
            Console.WriteLine("# New: F11                                                                    #");
            Console.WriteLine("###############################################################################");
            Console.WriteLine("*                                                                             *");
            Console.WriteLine("*                                                                             *");
            Console.WriteLine("*                                                                             *");
            Console.WriteLine("*                                                                             *");
            Console.WriteLine("*                                                                             *");
            Console.WriteLine("*                                                                             *");
            Console.WriteLine("*                                                                             *");
            Console.WriteLine("*                                                                             *");
            Console.WriteLine("*                                                                             *");
            Console.WriteLine("*                                                                             *");
            Console.WriteLine("*                                                                             *");
            Console.WriteLine("*                                                                             *");
            Console.WriteLine("*                                                                             *");
            Console.WriteLine("*                                                                             *");
            Console.WriteLine("*                                                                             *");
            Console.WriteLine("*                                                                             *");
            Console.WriteLine("*                                                                             *");
            Console.WriteLine("*                                                                             *");
            Console.WriteLine("*                                                                             *");
            Console.WriteLine("###############################################################################");
            Console.CursorTop = 4;
            Console.CursorLeft = 1;
            main();
        }

        public static void main()
        {
            ConsoleKeyInfo pressed_key = Console.ReadKey(); // read keystroke

            switch (pressed_key.Key)

            {
                case ConsoleKey.UpArrow: //Move cursor up
                    if (Console.CursorTop > 4)
                    {
                        Console.CursorTop = Console.CursorTop - 1;
                    }
                    break;

                case ConsoleKey.DownArrow: //Move cursor down
                    if (Console.CursorTop < 22)
                    {
                        Console.CursorTop = Console.CursorTop + 1;
                    }
                    break;

                case ConsoleKey.LeftArrow: //Move cursor left
                    if (Console.CursorLeft > 1)
                    {
                        Console.CursorLeft = Console.CursorLeft - 1;
                    }
                    break;

                case ConsoleKey.RightArrow: //Move cursor right
                    if (Console.CursorLeft < 77)
                    {
                        Console.CursorLeft = Console.CursorLeft + 1;
                    }
                    break;

                case ConsoleKey.Enter: //Start at the beggining of a new line
                    if (Console.CursorTop < 22)
                    {
                        Console.CursorTop = Console.CursorTop + 1;
                        Console.CursorLeft = 1;
                    }
                    break;
                case ConsoleKey.Backspace: //Remove characters
                    if (Console.CursorLeft > 1)
                    {
                        Console.CursorLeft = Console.CursorLeft - 1;
                        Console.Write(" ");
                        Console.CursorLeft = Console.CursorLeft - 1;
                    }
                    break;

                case ConsoleKey.F11: //Create a new document
                    Console.Clear();
                    init();
                    break;

                case ConsoleKey.F12: //Closes out of tdit
                    Console.Clear();
                    Console.WriteLine("Press F12 again if you see this."); // Kinda fixes it, bot not all the way.
                    return;
            }
            main();
        }
    }
}