using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _8bit
{
    class Program
    {


        static void Main(string[] args)
        {
            int[] regs = new int[16];//Хранить данные
            byte[] prog_mem = new byte[256];//Здесь будет файл-ключ.
            
            int pc = 0;//счетчик, указывает, где находится в prog_mem

            prog_mem = File.ReadAllBytes("decryptor.bin"); //файл-ключ
            string file = File.ReadAllText("q1.txt");//файл, что нужно расшифровать

            ///Для просмотра файла decryptor.bin
            int n = 0;
            foreach (byte b in prog_mem)
            {
                var temp = b.ToString("X2");

                Console.WriteLine("Это в  decryptor.bin " + n + ": " + temp);
                n++;
            }
            Console.WriteLine("--------------" );

            int file_pc = 0;
            bool in_flag = false; //флаг для окончания файла file
            bool Done = false;
            while (!Done)
            {

                byte first = prog_mem[pc++];
                byte second = prog_mem[pc++];

                int reg1 = second & 0x0F; // первые 4 бита  это регистр 1
                int reg2 = (second & 0xF0) >> 4;// вторые 4 - регистр 2



                switch (first)
                {
                    case 0x01: //INC
                        regs[reg1]++;
                        break;
                    case 0x02: //DEC
                        regs[reg1]--;
                        break;
                    case 0x03: //MOV
                        regs[reg1] = regs[reg2];
                        break;
                    case 0x04: //MOVC
                        regs[0] = second;
                        break;
                    case 0x05: //LSL
                        regs[reg1] = (byte)(regs[reg1] << 1);
                        break;
                    case 0x06: //LSR
                        regs[reg1] = (byte)(regs[reg1] >> 1);
                        break;
                    case 0x07: //JMP
                        pc -= 2;
                        pc += (sbyte)second;
                        break;
                    case 0x0A: //JFE
                        if (in_flag == true)
                        {
                            pc -= 2;
                            pc += (sbyte)second;
                        }
                        break;
                    case 0x0B: //RET
                        Console.WriteLine("\n-------------\nDone");
                        Done = true;
                        break;
                    case 0x0C: //ADD
                        regs[reg1] = (byte)(regs[reg1] + regs[reg2]);
                        break;
                    case 0x0D: //SUB
                        regs[reg1] = (byte)(regs[reg1] - regs[reg2]);
                        break;
                    case 0x0E: //XOR
                        regs[reg1] = (byte)(regs[reg1] ^ regs[reg2]);
                        break;
                    case 0x0F: //OR
                        regs[reg1] = (byte)(regs[reg1] | regs[reg2]);
                        break;
                    case 0x10: //IN
                        if (file_pc < file.Length)
                        {
                            regs[reg1] = file[file_pc];
                            file_pc++;
                        }
                        if (file_pc>=file.Length)
                            in_flag =true;
                        break;
                    case 0x11: //OUT
                        Console.Write((char)regs[reg1]);
                        break;
                    
                }
            }
        }



    }
}

