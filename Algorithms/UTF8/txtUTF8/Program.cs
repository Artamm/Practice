using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace weeps
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("Start:");
            byte[] file2 = Encoding.UTF8.GetBytes(File.ReadAllText("386intel.txt"));
            byte[] file1  = System.IO.File.ReadAllBytes("386intel.txt");
            byte[] file = UTF8Encoding.UTF8.GetBytes(File.ReadAllText("386intel.txt",Encoding.UTF8));

                    
            

            string cp = File.ReadAllText("table_2.txt", Encoding.UTF8);
            string[] cp437 = System.IO.File.ReadAllLines("table_2.txt");
            List<string> Table = new List<string>();
            List<string> Table2 = new List<string>();

            for (int i = 0; i < cp437.Length; i++)
            {
                foreach (string element in cp437[i].Split(' '))
                {
                    Table.Add(element);
                    Console.WriteLine("Another add: " + element);

                }
            }
            File.WriteAllText("chek.txt", string.Join("", Table), Encoding.UTF8);

            foreach (string element in cp.Split(' '))
            {
                Table2.Add(element);
            }
            foreach (string element in Table)
            {
                Console.WriteLine(element) ;
            }

            string temp;
            int position;
            List<string> writeIn = new List<string>();

            foreach (byte b in file1)
            {
                if (b < 128)
                {
                    temp = Encoding.UTF8.GetString((new[] { b }));
                    if (b == 16)
                        temp= "►";
                    if (b == 31)
                        temp = "▼";
                    if (b == 30)
                        temp = "▲";
                    if (b == 17)
                        temp = "◄";
                    if (b == 7)
                        temp = "•";
                    if (b == 27)
                        temp = "←";
                    if (b == 26)
                        temp = "→";
                    if (b == 25)
                        temp = "↓";
                    if (b == 24)
                        temp = "↑";

                    writeIn.Add(temp);

                }
                if (b>127)
                {
                    temp = b.ToString();
                    position= Table.IndexOf(temp) + 1;
                    temp = Table[position];
                    
                    // byte[] vremenno = StringToByteArray(temp);

                    writeIn.Add(temp);

                }
               


            }
            Console.WriteLine(string.Join("", writeIn));
 File.WriteAllText("readme_.txt", string.Join("", writeIn),Encoding.UTF8);
        }
        

    }





}
