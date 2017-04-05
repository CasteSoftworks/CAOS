using CAOS;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using CaOS;
using Sys = Cosmos.System;








namespace CaOS
{
    public class Kernel : Sys.Kernel
    {
        string version = "20170301";
        string pass = "";
        string user1 = "User1";
        string user2 = "User2";
        string error = "Unknown command. For a complete list of commands use help.";
        bool useruno = true;
        public bool FSinit = false;
        string current_path = @"0:\";
        public bool firstlog = true;
        public bool SudoY = false;
        public string username = "";
        public bool noerror = true; //For a while(_) like use

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
            Console.WriteLine("**********************    CasteSoftworks " + version + "      ******************");
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
                goto user1;
            }
            else if (filesys == "N" || filesys == "n")
            {
                Console.WriteLine("File System Will NOT Be Initialized!");
                goto user1;
            }
            else
            {
                goto filesystem;
            }

            user1:
            try
            {
                if (File.Exists("0:\\login\\user_nme.txt") && File.Exists("0:\\login\\pass_wrd.txt"))
                {
                    firstlog = false;
                    goto login;
                }
                else if ((Directory.Exists("0:\\login\\")))
                {
                    CAFS.createFile("0:\\login\\user_name.txt");
                    CAFS.createFile("0:\\login\\pass_wrd.txt");
                    goto login;
                }
                else
                {
                    CAFS.createDir("0:\\login");
                    CAFS.createFile("0:\\login\\user_name.txt");
                    CAFS.createFile("0:\\login\\pass_wrd.txt");
                    goto login;
                }

                login:
                if (firstlog)
                {
                    Console.Write("Set the user's name: ");
                    var nomeutente = Console.ReadLine();
                    CAFS.writeText("0:\\login\\user_name.txt", nomeutente);
                    Console.Write("Set password: ");
                    var passwrd = Console.ReadLine();
                    CAFS.writeText("0:\\login\\pass_wrd.txt", passwrd);
                }
                else
                {
                    Console.WriteLine("You must log in!");
                    setuser:
                    Console.Write("User: ");
                    var user = Console.ReadLine();
                    var usernm = File.ReadAllText("0:\\login\\user_name.txt");
                    if (user == usernm)
                    {
                        Console.WriteLine(user + "recognized");
                        user = username;
                    }
                    else
                    {
                        Console.WriteLine("Not correct username");
                        goto setuser;
                    }
                    setpsswrd:
                    Console.Write("Password: ");
                    var passwd = Console.ReadLine();
                    var passwdrd = File.ReadAllText("0:\\login\\pass_wrd.txt");
                    if (passwd == passwdrd)
                    {
                        goto booted;
                    }
                    else
                    {
                        Console.WriteLine("Not correct password" + user);
                        goto setpsswrd;
                    }
                }
            }

            catch
            {
                goto booted;
            }
                
            
            

            booted:
            Console.Clear();
            Console.WriteLine("           ************    ************    ************    ************     ");
            Console.WriteLine("          *               *          *    *          *    *                 ");
            Console.WriteLine("         #               ############    #          #    ############       ");
            Console.WriteLine("        #               #          #    #          #               #        ");
            Console.WriteLine("       @               @          @    @          @               @         ");
            Console.WriteLine("      @@@@@@@@@@@@    @          @    @@@@@@@@@@@@    @@@@@@@@@@@@          ");
            Console.WriteLine("                                                                            ");
            Console.WriteLine("                             Successfully booted                            ");
            Console.WriteLine("                                                                            ");
            inizia:
            Console.Write(username + " do you want to start?(Y/N)");
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
            try
            {
                switch (co)
                {

                    case "reboot":    //Reboots the machine
                        Cosmos.System.Power.Reboot();
                        break;

                    case "shutdown":   //Shuts down the machine
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

                    case "clear":   //Clears the screen
                        Console.Clear();
                        break;

                    case "help":  //All the commands
                        Console.WriteLine("Help 1: Normal Commands");
                        Console.WriteLine("--------------------------------------------------------");
                        Console.WriteLine("                                ");
                        Console.WriteLine("Reboot = reboot");
                        Console.WriteLine("Shutdown = shutdown");
                        Console.WriteLine("Clear = clear");
                        Console.WriteLine("About CAOS = about");
                        Console.WriteLine("Lock = lock");
                        Console.WriteLine("Print something on screen = print/things to print");
                        Console.WriteLine("Become user with sudo privilges = sudo");
                        Console.WriteLine("Help page 2 (FileSystem) = help2");
                        Console.WriteLine("Help page 3 (Calculator) = help3");
                        break;
                    case "help2":
                        Console.WriteLine("Help 2: FileSystem");
                        Console.WriteLine("--------------------------------------------------------");
                        Console.WriteLine("                                ");
                        Console.WriteLine("Go to specified directory = cd/directory");
                        Console.WriteLine("Create directory = md/new directory's name");
                        Console.WriteLine("Show current directories = dir");
                        Console.WriteLine("Use basic text editor = microtxt");
                        Console.WriteLine("Deletes the specified directory[sudo] = dd/directory*");
                        Console.WriteLine("                                ");
                        Console.WriteLine("*type helpdir to know what directories not to delete");
                        break;
                    case "help3":
                        Console.WriteLine("Help 3: Calculator*");
                        Console.WriteLine("--------------------------------------------------------");
                        Console.WriteLine("                                ");
                        Console.WriteLine("Add two numbers together = add/num1#num2");
                        Console.WriteLine("Subtract a number to an other = subtract/num1#num2");
                        Console.WriteLine("Muliply two numbers together = multiply/num1#num2");
                        Console.WriteLine("Divide one number with another number = divide/num1#num2");
                        Console.WriteLine("One nuber to the power of another = power/num1#num2");
                        Console.WriteLine("Least Common Number of two numbers = lcm/num1#num2");
                        Console.WriteLine("Greatest Common Factor of two numbers = gcf/num1#num2");
                        Console.WriteLine("                                ");
                        Console.WriteLine("*it not works with decimals(0.1 for example)");
                        break;
                    case "helpdir":
                        Console.WriteLine("Do not delete the directories TEST, Testing, 0 because");
                        Console.WriteLine("they are system's directoryes and deleting them will cause");
                        Console.WriteLine("the Blue Screen of Error");
                        break;

                    case "lock":
                        Console.Write("Set Passcode: ");
                        pass = Console.ReadLine();
                        lockkernel.lockpass(pass);
                        break;

                    case "print":   //Prints something
                        Console.WriteLine(vars);
                        break;

                    case "about":  //Some information
                        Console.WriteLine("CAOS , CasteSoftworks " + version + " for help castesoftworks@fastservice.com");
                        Console.WriteLine("or go to our site castesoftworks.site90.com or to our Facebook page");
                        break;

                    case "cd":  //Changes current directory 
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



                    case "microtxt":
                        Console.Clear();
                        microtxt.init();
                        break;


                    //case "BASIC": working on basic-style programming
                    //Console.Clear();
                    //Basic.init();
                    //break;

                    case "sudo": //Become sudo user
                        Console.Write("Are you sure to become a sudo user?(Y/N)");
                        var sicuro = Console.ReadLine();
                        if (sicuro == "Y" || sicuro == "y")
                        {
                            SudoY = true;
                        }
                        else
                        {
                            SudoY = false;
                        }
                        break;

                    case "dd":
                        if (SudoY)
                        {
                            CAFS.deleteDir(current_path + vars);
                        }
                        else
                        {
                            Console.WriteLine("I'm sorry, you aren't a sudo user");
                        }
                        break;

                    case "program": // Launches optional packages
                        string packageid = vars;
                        CaOS.Runner.packages(packageid);
                        break;

                    default:
                        Console.WriteLine(error);
                        break;
                }
            }
            catch (Exception e) //BlueScreenOfDeath-like thing I wanted to make noerror false but it bugs
            {

                Console.BackgroundColor = ConsoleColor.Blue;
                Console.Clear();
                Console.WriteLine("           ************    ************    ************    ************      ");
                Console.WriteLine("          *               *          *    *          *    *                  ");
                Console.WriteLine("         #               ############    #          #    ############        ");
                Console.WriteLine("        #               #          #    #          #               #         ");
                Console.WriteLine("       @               @          @    @          @               @          ");
                Console.WriteLine("      @@@@@@@@@@@@    @          @    @@@@@@@@@@@@    @@@@@@@@@@@@           ");
                Console.WriteLine("                                                                             ");
                Console.WriteLine("   I'm sorry but a fatal error occurred, I will power off your system and    ");
                Console.WriteLine("   hope that nothing has been damaged                                        ");
                Console.WriteLine("                                                                             ");
                Console.WriteLine("   CasteSoftworks hasn't got any responsability on any type of damage        ");
                Console.WriteLine("                                                                             ");
                Console.WriteLine("    " + e);
                Console.WriteLine("                                                                             ");
                spegni:
                Console.Write("   Do you want to reboot or shutdown?(R/S)");
                var risp = Console.ReadLine();
                if (risp == "R" || risp == "r")
                {
                    Sys.Power.Reboot();
                }
                else if (risp == "S" || risp == "s")
                {
                    Stop();
                }
                else
                {
                    goto spegni;
                }
            }
        }
    }
}
