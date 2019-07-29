using System;
using System.IO;
using System.Linq;
using System.Text;

namespace MultiplesOfNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start!");
            string FileToRead = "file1.txt";
            string FileOut = "file2.txt";
            ReadWriteFile(FileToRead, FileOut);
            Console.WriteLine("End!");
            Console.ReadLine();
        }
        static void ReadWriteFile(string fileRead, string fileOut)
        {
            using (FileStream stream = File.OpenRead(fileRead))
            using (var writeStream = new StreamWriter(fileOut))
            {
                using (var streamReader = new StreamReader(stream, Encoding.UTF8))
                {
                    string line;
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        writeStream.WriteLine(IsMultiple(line, 3));
                    }
                }
            }
        }

        static string IsMultiple(string numbers, int multiple)
        {
            int number = 0;
            while (true)
            {

                foreach (var ctr in numbers.ToArray())
                    number += Convert.ToInt32(ctr.ToString().IsNumeric() == true ? ctr.ToString() : "0");

                if (number < 10)
                {
                    if ((number % multiple) == 0)
                    {
                        return "SI";
                    }
                    else
                    {
                        return "NO";
                    }
                }
                else
                {
                    numbers = number.ToString();
                    number = 0;
                }

            }
        }
    }

    static class StringExtensions
    {
        public static bool IsNumeric(this string input)
        {
            int number;
            return int.TryParse(input, out number);
        }
    }
}
