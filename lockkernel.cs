using System;



namespace CaOS

{

    class lockkernel

    {

        public static void lockpass(string passcode)
        {
            bool unlocked = false;
            while (!unlocked)
            {
                Console.Clear();
                Console.WriteLine("     ************    ************    ************    ************");
                Console.WriteLine("    *               *          *    *          *    *            ");
                Console.WriteLine("   #               ############    #          #    ############  ");
                Console.WriteLine("  #               #          #    #          #               #   ");
                Console.WriteLine(" @               @          @    @          @               @    ");
                Console.WriteLine("@@@@@@@@@@@@    @          @    @@@@@@@@@@@@    @@@@@@@@@@@@     ");
                Console.WriteLine("                                                                 ");
                Console.WriteLine("            System Locked, Type Password to unlock               ");
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