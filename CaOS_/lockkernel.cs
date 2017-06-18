using System;



namespace CaOS_

{

    class lockkernel

    {

        public static void lockpass(string passcode)
        {
            string version = "2017-06-16";
            bool unlocked = false;
            while (!unlocked)
            {
                Console.Clear();
                logo.Logo(version);
                Console.WriteLine("                                                                                ");
                Console.WriteLine("                                System Locked                                   ");
                Console.WriteLine("                                                                                ");
                Console.Write("Password: ");
                string enterpass = Console.ReadLine();
                if (enterpass == passcode)
                {
                    unlocked = true;
                    Console.Clear();
                }
            }
        }
    }
}