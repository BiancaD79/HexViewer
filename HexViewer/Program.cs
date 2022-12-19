using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexViewer
{
    class Program
    {
        static string path;
        static void Main(string[] args)
        {
            path = Console.ReadLine();
            //C:\Users\bianc\Desktop\lorem.txt
            FileStream file = new FileStream(path, FileMode.Open);
            int line;
            int counter = 0;
            int rowcounter = 0;
            StringBuilder sidetext = new StringBuilder();
            Console.Write("00000000: ");
                rowcounter++;
            while ((line = file.ReadByte()) != -1)
            {
                string value = string.Format("{0:X2}", line);
                if (value != "0D") // 0D0A carriage return and line feed
                {
                    char character = Convert.ToChar(line);
                    if (line > 0 && line < 32) // verify if it's a special character
                        sidetext.Append(".");
                    else
                        sidetext.Append(character);
                    counter++;
                    if (counter !=9 && counter < 16)
                    {
                        Console.Write(value + " ");
                    }
                    else
                    {
                        if (counter == 9) Console.Write($"|{value} "); // halfway
                        else
                        {
                            
                            Console.Write(value + " ");
                            Console.WriteLine("|" + sidetext);
                            sidetext.Clear();
                            Console.Write(rowcounter.ToString("X" + 8));
                            Console.Write(": ");
                            counter = 0;
                            rowcounter++;
                        }
                    }
                }
            }
            while (counter < 16)
            {
                if (counter == 8) Console.Write($"|00 ");
                else
                    Console.Write("00 "); counter++; 
            }
            Console.WriteLine("|" + sidetext);
            Console.ReadKey();
        }
    }
}
