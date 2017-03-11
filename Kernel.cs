using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;

namespace CaOS
{
    public class Kernel : Sys.Kernel
    {
        string version = "20170305";
        string pass = "";
        string user1 = "User1";
        string user2 = "User2";
        string error = "Unknown command. For a complete list of commands use help.";
        bool useruno = true;
        public bool FSinit = false;
        string current_path = @"0:\";

        protected override void BeforeRun()
        {
            Console.Clear();


            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("     +++++++++         ++++++++++         ++++++++++++++          +++++++++++   ");
            Console.WriteLine("     +++               +++    +++         +++        +++          +++           ");
            Console.WriteLine("     !!!               !!!    !!!         !!!        !!!          !!!           ");
            Console.WriteLine("     !!!               !!!!!!!!!!         !!!        !!!          !!!!!!!!!!!   ");
            Console.WriteLine("     |||               |||    |||         |||        |||                  |||   ");
            Console.WriteLine("     |||               |||    |||         |||        |||                  |||   ");
            Console.WriteLine("     [][][][][         [][    ][]         [][][][][][][]          [][][][][][   ");
            Console.WriteLine("                                                                                ");
            Console.WriteLine("**********************    CasteSoftworks " + version + "    ******************");
            Console.WriteLine("                                                                                ");
            Console.WriteLine("**********************                Setup               **********************");
            filesystem:
            Console.Write("Do you want to enable the file system *IT CAN DAMAGE THE MACHINE* (Y/N)?");
            var filesys = Console.ReadLine();
            if (filesys == "Y" || filesys == "y")
            {
                FSinit = true;
                Console.WriteLine("File System Will Be Initialized!");

                var fs = new Sys.FileSystem.CosmosVFS();

                Sys.FileSystem.VFS.VFSManager.RegisterVFS(fs);
                goto setupcolore;
            }
            else if (filesys == "N" || filesys == "n")
            {
                Console.WriteLine("File System Will NOT Be Initialized!");
                goto setupcolore;
            }
            else
            {
                goto filesystem;
            }
            setupcolore:
            Console.Write("Font color W(white) or G(green)?(W/G)");
            var colore = Console.ReadLine();
            if (colore == "W" || colore == "w")
            {
                goto user1;
            }
            else if (colore == "G" || colore == "g")
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                goto user1;
            }
            else
            {
                goto setupcolore;
            }
            user1:
            Console.Write("What user do you want to use?(1/2)");
            var utente = Console.ReadLine();
            if (utente == "1")
            {
                goto nomeutente;
            }
            else if (utente == "2")
            {
                useruno = false;
                goto nomeutente;
            }
            else
            {
                goto user1;
            }
            nomeutente:
            Console.Write("Set the user's name: ");
            var nomeutente = Console.ReadLine();
            if (useruno)
            {
                user1 = nomeutente;
                goto booted;
            }
            else
            {
                user2 = nomeutente;
                goto booted;
            }

            booted:
            Console.Clear();
            Console.WriteLine("     ************    ************    ************    ************");
            Console.WriteLine("    *               *          *    *          *    *            ");
            Console.WriteLine("   #               ############    #          #    ############  ");
            Console.WriteLine("  #               #          #    #          #               #   ");
            Console.WriteLine(" @               @          @    @          @               @    ");
            Console.WriteLine("@@@@@@@@@@@@    @          @    @@@@@@@@@@@@    @@@@@@@@@@@@     ");
            Console.WriteLine("                                                                 ");
            Console.WriteLine("                       Successfully booted                       ");
            inizia:
            Console.Write("Start?(Y/N)");
            var sino = Console.ReadLine();
            if (sino == "Y" || sino == "y")
            {
                Console.Clear();
            }
            else if (sino == "N" || sino == "n")
            {
                Stop();
            }
            else
            {
                goto inizia;
            }
        }


        protected override void Run()
        {
            Console.Write(current_path + "~|>");
            var input = Console.ReadLine();
            var co = input;
            var vars = "";
            if (input.ToLower().IndexOf('/') != -1)
            {

                string[] parts = input.Split('/');
                co = parts[0];
                vars = parts[1];
            }
            switch (co)
            {

                case "reboot":
                    Cosmos.System.Power.Reboot();
                    break;

                case "shutdown":
                    if (useruno)
                    {
                        Console.WriteLine("now you can power off your system, " + user1 + ".");
                        Stop();
                    }
                    else
                    {
                        Console.WriteLine("now you can power off your system, " + user2 + ".");
                        Stop();
                    }
                    break;

                case "clear":
                    Console.Clear();
                    break;

                case "help":
                    Console.WriteLine("With or without the File system:");
                    Console.WriteLine("                                ");
                    Console.WriteLine("Reboot = reboot");
                    Console.WriteLine("Shutdown = shutdown");
                    Console.WriteLine("Clear = clear");
                    Console.WriteLine("About CAOS = about");
                    Console.WriteLine("Lock = lock");
                    Console.WriteLine("Print something on screen = print/things to print");
                    Console.WriteLine("                                ");
                    Console.WriteLine("                                ");
                    Console.WriteLine("Only with File System:");
                    Console.WriteLine("                                ");
                    Console.WriteLine("Go to specified directory = cd/directory");
                    Console.WriteLine("Create directory = md/new directory's name");
                    Console.WriteLine("Show current directories = dir");
                    Console.WriteLine("Use basic text editor = microtxt");
                    Console.WriteLine("                                ");
                    Console.WriteLine("                                ");
                    Console.WriteLine("Calculator Commands:");
                    Console.WriteLine("                                ");
                    Console.WriteLine("Add two numbers together = add/num1#num2");
                    Console.WriteLine("Subtract a number to an other = subtract/num1#num2");
                    Console.WriteLine("Muliply two numbers together = multiply/num1#num2");
                    Console.WriteLine("Divide one number with another number = divide/num1#num2");
                    Console.WriteLine("One nuber to the power of another = power/num1#num2");
                    Console.WriteLine("Least Common Number of two numbers = lcm/num1#num2");
                    Console.WriteLine("Greatest Common Factor of two numbers = gcf/num1#num2");
                    break;

                case "lock":
                    Console.Write("Set Passcode: ");
                    pass = Console.ReadLine();
                    lockkernel.lockpass(pass);
                    break;

                case "print":
                    Console.WriteLine(vars);
                    break;

                case "about":
                    Console.WriteLine("CAOS , CasteSoftworks " + version + " for help castesoftworks@fastservice.com");
                    Console.WriteLine("or go to our site castesoftworks.000webhostapp.com");
                    break;

                case "cd":
                    if (FSinit)
                    {
                        current_path = vars;
                    }
                    else
                    {
                        Console.WriteLine("File System Not Enabled!");
                    }
                    break;

                case "md":  // Makes new directory
                    if (FSinit)

                    {
                        CAFS.createDir(current_path + vars);
                    }
                    else
                    {
                        Console.WriteLine("File System Not Enabled!");
                    }
                    break;

                case "dir": // Displays current location
                    if (FSinit)
                    {
                        string[] back = CAFS.readFiles(current_path);
                        string[] front = CAFS.readDirectories(current_path);
                        string[] combined = new string[front.Length + back.Length];
                        Array.Copy(front, combined, front.Length);
                        Array.Copy(back, 0, combined, front.Length, back.Length);
                        foreach (var item in combined)
                        {
                            Console.WriteLine(item.ToString());
                        }
                    }
                    else
                    {
                        Console.WriteLine("File System Not Enabled!");
                    }
                    break;

                case "microtxt": // Launches text editor
                    if (FSinit)
                    {
                        Console.Clear();
                        microtxt.init();
                        break;
                    }
                    else
                    {
                        Console.WriteLine("File System Not Enabled!");
                    }
                    break;

                case "add": // Adds given numbers
                    string[] inputvarsa = vars.Split('#');
                    Console.WriteLine(CAOS.Mate.Add(inputvarsa[0], inputvarsa[1]));
                    break;

                case "subtract": // Subtracts given numbers
                    string[] inputvarsb = vars.Split('#');
                    Console.WriteLine(CAOS.Mate.Subtract(inputvarsb[0], inputvarsb[1]));
                    break;

                case "multiply": // Multiplys given numbers
                    string[] inputvarsc = vars.Split('#');
                    Console.WriteLine(CAOS.Mate.Multiply(inputvarsc[0], inputvarsc[1]));
                    break;

                case "divide": // Divides given numbers
                    string[] inputvarsd = vars.Split('#');
                    Console.WriteLine(CAOS.Mate.Divide(inputvarsd[0], inputvarsd[1]));
                    break;

                case "power": // Raises given number to other given number
                    string[] inputvarse = vars.Split('#');
                    Console.WriteLine(CAOS.Mate.ToPower(inputvarse[0], inputvarse[1]));
                    break;

                case "gcd": // Gives gcd conversion of given numbers
                    string[] inputvarsf = vars.Split('#');
                    Console.WriteLine(CAOS.Mate.GcdCon(inputvarsf[0], inputvarsf[1]));
                    break;

                case "lcm": // Gives lcm conversion of given numbers
                    string[] inputvarsg = vars.Split('#');
                    Console.WriteLine(CAOS.Mate.LcmCon(inputvarsg[0], inputvarsg[1]));
                    break;

                default:
                    Console.WriteLine(error);
                    break;
            }
        }
    }
}
