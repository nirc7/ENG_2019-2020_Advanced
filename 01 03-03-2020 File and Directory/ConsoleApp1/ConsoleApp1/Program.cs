using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("file.txt");
            string str = sr.ReadLine();
            while (!sr.EndOfStream)
            {
                Console.WriteLine(sr.ReadLine());
            }
            sr.Close();
            Console.WriteLine();
            sr = new StreamReader("file.txt");
            str = sr.ReadToEnd();
            Console.WriteLine(str);
            sr.Close();

            //str.Replace(" ", "");
            Console.WriteLine("________________");
            string[] lines = str.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);// "\r\n"
            foreach (var item in lines)
            {
                Console.WriteLine(item);
            }

            StreamWriter sw = new StreamWriter("file.txt");
            sw.WriteLine("avi");
            sw.WriteLine("benny");
            sw.Close();


            string filePath = Directory.GetCurrentDirectory();
            Console.WriteLine(filePath);
            FileInfo fi = new FileInfo("file.txt");
            Console.WriteLine(fi.Extension);
            Console.WriteLine(fi.CreationTime);
            Console.WriteLine(fi.Name );

            File.AppendAllText("file.txt","charlie");
            //Directory.



        }
    }

    class Person
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
