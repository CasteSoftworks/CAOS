using System;
using System.IO;
using System.Text;

namespace CaOS

{

    class CAFS

    {

        public static void writeFile(string Adr, string[] data) // Write text to a file
        {
            File.WriteAllLines(Adr, data);
        }

        public static string[] readFile(string Adr) // Read text from a file
        {
            string[] read;
            read = File.ReadAllLines(Adr);
            return read;
        }

        public static void createDir(string Adr) //Create a folder

        {
            Directory.CreateDirectory(Adr);
        }

        public static void deleteDir(string Adr)
        {
            Directory.Delete(Adr);
        }

        public static string[] readFiles(string Adr) // Get Files From Address
        {
            string[] Files = new string[256];
            if (Directory.GetFiles(Adr).Length > 0)
                Files = Directory.GetFiles(Adr);
            else
                Files[0] = "No files found.";
            return Files;
        }

        public static string[] readDirectories(string Adr) // Get Directories From Address
        {
            var Dirs = Directory.GetDirectories(Adr);
            return Dirs;
        }

        public static bool directoryExists(string Adr) // Test to see if a given adress actually exists.

        {
            Console.WriteLine("Not Implemented!");
            return false;
        }

        public string[] ReadLines(string FileAdr) //Returns the lines of text in string[].
        {
            string[] FileRead;
            FileRead = File.ReadAllLines(FileAdr);
            return FileRead;
        }

        public string ReadText(string FileAddr) //Returns the file in a single string.
        {
            string f_contents = "";
            f_contents = File.ReadAllText(FileAddr);
            return f_contents;
        }

        public byte[] ReadByte(string FileAdr) //Returns the readed file in bytes.
        {
            byte[] FileRead;
            FileRead = File.ReadAllBytes(FileAdr);
            return FileRead;
        }
        

    }

}