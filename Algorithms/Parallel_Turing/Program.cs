using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


namespace PRL_TRM
{
    class Program
    {
        static void Main(string[] args)
        {
            //------1-----------------------------------------------------------------------------
            string state = "0";// состояние головки машины 
            string[] file_to;// копируется файл для работы (построчно)
            bool check = true;
            file_to = System.IO.File.ReadAllLines("2.txt");// для работы с файлами

            int forHead = Int32.Parse(file_to[0]) - 1; ;//переводим в int
            List<string> rule = new List<string>(); //список для правил
            List<string> tape = new List<string>();//список для Tape
            List<string> bolvanka = new List<string>(file_to[1].Length);

            foreach (string element in file_to[1].Split(' '))
            {
                tape.Add(element);
                bolvanka.Add(" ");
            }

            tape.RemoveAt(tape.Count - 1);//убираем \n

            for (int i = 2; i < file_to.Length; i++)
            {
                foreach (string element in file_to[i].Split(' '))
                    rule.Add(element);
            }

            List<string> State1 = new List<string>();   //  первое состояние МТ
            List<string> original = new List<string>(); //  для проверки с tape[forHead]
            List<string> changeTo = new List<string>(); //  для того, чтобы поменять значение tape[forHead]
            List<string> position = new List<string>(); //  для смены позиции
            List<string> State2 = new List<string>();   //  для смены состояния
            bolvanka[forHead] = "^";
            //  Добавляем в списки. Так как столбцов ровно 5, то к каждому циклу +5

            for (int i = 0; i < rule.Count; i = i + 5)
                State1.Add(rule[i]);
            for (int i = 1; i < rule.Count; i = i + 5)
                original.Add(rule[i]);
            for (int i = 2; i < rule.Count; i = i + 5)
                changeTo.Add(rule[i]);
            for (int i = 3; i < rule.Count; i = i + 5)
                position.Add(rule[i]);
            for (int i = 4; i < rule.Count; i = i + 5)
                State2.Add(rule[i]);

            //  Проверяем, скопировано ли все правильно. Все значение должны быть одинаковы

            Console.WriteLine("Length of each line: " + State1.Count + " | " + original.Count + " | " + changeTo.Count + " | " + position.Count + " | " + State2.Count);
            
            int r = 0;

            //--------------------------------------------------------------------------------------------------------------------


            //------2-----------------------------------------------------------------------------
            string state_2 = "0";// состояние головки машины 
            string[] file_to_2;// копируется файл для работы (построчно)
            bool check_2 = true;
            file_to_2 = System.IO.File.ReadAllLines("increment_dec.tmprog.txt");// для работы с файлами

            int forHead_2 = Int32.Parse(file_to_2[0]) - 1; ;//переводим в int
            List<string> rule_2 = new List<string>(); //список для правил
            List<string> tape_2 = new List<string>();//список для Tape
            List<string> bolvanka_2 = new List<string>(file_to_2[1].Length);

            foreach (string element in file_to_2[1].Split(' '))
            {
                tape_2.Add(element);
                bolvanka_2.Add(" ");
            }

            tape_2.RemoveAt(tape_2.Count - 1);//убираем \n

            for (int i = 2; i < file_to_2.Length; i++)
            {
                foreach (string element in file_to_2[i].Split(' '))
                    rule_2.Add(element);
            }

            List<string> State1_2 = new List<string>();   //  первое состояние МТ
            List<string> original_2 = new List<string>(); //  для проверки с tape[forHead]
            List<string> changeTo_2 = new List<string>(); //  для того, чтобы поменять значение tape[forHead]
            List<string> position_2 = new List<string>(); //  для смены позиции
            List<string> State2_2 = new List<string>();   //  для смены состояния
            bolvanka_2[forHead_2] = "^";
            //  Добавляем в списки. Так как столбцов ровно 5, то к каждому циклу +5

            for (int i = 0; i < rule_2.Count; i = i + 5)
                State1_2.Add(rule_2[i]);
            for (int i = 1; i < rule_2.Count; i = i + 5)
                original_2.Add(rule_2[i]);
            for (int i = 2; i < rule_2.Count; i = i + 5)
                changeTo_2.Add(rule_2[i]);
            for (int i = 3; i < rule_2.Count; i = i + 5)
                position_2.Add(rule_2[i]);
            for (int i = 4; i < rule_2.Count; i = i + 5)
                State2_2.Add(rule_2[i]);

            //  Проверяем, скопировано ли все правильно. Все значение должны быть одинаковы

            Console.WriteLine("Length of each line: " + State1.Count + " | " + original.Count + " | " + changeTo.Count + " | " + position.Count + " | " + State2.Count);
           
            int r_2 = 0;

            //--------------------------------------------------------------------------------------------------------------------

            //------3-----------------------------------------------------------------------------
            string state_3 = "0";// состояние головки машины 
            string[] file_to_3;// копируется файл для работы (построчно)
            bool check_3 = true;
            file_to_3 = System.IO.File.ReadAllLines("3.txt");// для работы с файлами

            int forHead_3 = Int32.Parse(file_to_3[0]) - 1; ;//переводим в int
            List<string> rule_3 = new List<string>(); //список для правил
            List<string> tape_3 = new List<string>();//список для Tape
            List<string> bolvanka_3 = new List<string>(file_to_3[1].Length);

            foreach (string element in file_to_3[1].Split(' '))
            {
                tape_3.Add(element);
                bolvanka_3.Add(" ");
            }

            tape_3.RemoveAt(tape_3.Count - 1);//убираем \n

            for (int i = 2; i < file_to_3.Length; i++)
            {
                foreach (string element in file_to_3[i].Split(' '))
                    rule_3.Add(element);
            }

            List<string> State1_3 = new List<string>();   //  первое состояние МТ
            List<string> original_3 = new List<string>(); //  для проверки с tape[forHead]
            List<string> changeTo_3 = new List<string>(); //  для того, чтобы поменять значение tape[forHead]
            List<string> position_3 = new List<string>(); //  для смены позиции
            List<string> State2_3 = new List<string>();   //  для смены состояния
            bolvanka_3[forHead_3] = "^";
            //  Добавляем в списки. Так как столбцов ровно 5, то к каждому циклу +5

            for (int i = 0; i < rule_3.Count; i = i + 5)
                State1_3.Add(rule_3[i]);
            for (int i = 1; i < rule_3.Count; i = i + 5)
                original_3.Add(rule_3[i]);
            for (int i = 2; i < rule_3.Count; i = i + 5)
                changeTo_3.Add(rule_3[i]);
            for (int i = 3; i < rule_3.Count; i = i + 5)
                position_3.Add(rule_3[i]);
            for (int i = 4; i < rule_3.Count; i = i + 5)
                State2_3.Add(rule_3[i]);

            //  Проверяем, скопировано ли все правильно. Все значение должны быть одинаковы

            int r_3 = 0;

            //--------------------------------------------------------------------------------------------------------------------
            //------4-----------------------------------------------------------------------------
            string state_4 = "0";// состояние головки машины 
            string[] file_to_4;// копируется файл для работы (построчно)
            bool check_4 = true;
            file_to_4 = System.IO.File.ReadAllLines("1_.txt");// для работы с файлами

            int forHead_4 = Int32.Parse(file_to_4[0]) - 1; ;//переводим в int
            List<string> rule_4 = new List<string>(); //список для правил
            List<string> tape_4 = new List<string>();//список для Tape
            List<string> bolvanka_4 = new List<string>(file_to_4[1].Length);

            foreach (string element in file_to_4[1].Split(' '))
            {
                tape_4.Add(element);
                bolvanka_4.Add(" ");
            }

            tape_4.RemoveAt(tape_4.Count - 1);//убираем \n

            for (int i = 2; i < file_to_4.Length; i++)
            {
                foreach (string element in file_to_4[i].Split(' '))
                    rule_4.Add(element);
            }

            List<string> State1_4 = new List<string>();   //  первое состояние МТ
            List<string> original_4 = new List<string>(); //  для проверки с tape[forHead]
            List<string> changeTo_4 = new List<string>(); //  для того, чтобы поменять значение tape[forHead]
            List<string> position_4 = new List<string>(); //  для смены позиции
            List<string> State2_4 = new List<string>();   //  для смены состояния
            bolvanka_4[forHead_4] = "^";
            //  Добавляем в списки. Так как столбцов ровно 5, то к каждому циклу +5

            for (int i = 0; i < rule_4.Count; i = i + 5)
                State1_4.Add(rule_4[i]);
            for (int i = 1; i < rule_4.Count; i = i + 5)
                original_4.Add(rule_4[i]);
            for (int i = 2; i < rule_4.Count; i = i + 5)
                changeTo_4.Add(rule_4[i]);
            for (int i = 3; i < rule_4.Count; i = i + 5)
                position_4.Add(rule_4[i]);
            for (int i = 4; i < rule_4.Count; i = i + 5)
                State2_4.Add(rule_4[i]);

            //  Проверяем, скопировано ли все правильно. Все значение должны быть одинаковы

            int r_4 = 0;

            //--------------------------------------------------------------------------------------------------------------------


            while (true)  //до тех пор пока головка не вышла за пределы (не HALT)
            {

                if (r < State1.Count) //количество правил равно 5
                {
                    if (forHead > 0 || forHead < tape.Count)
                        if (state == State1[r])
                        {
                            if (tape[forHead] == original[r])
                            {

                                if (changeTo[r] != "*")
                                    tape[forHead] = changeTo[r];

                                //  if (forHead_3 < 0 || forHead_3 >= tape_3.Count)
                                // Console.WriteLine(string.Join("", tape_3));
                                if (position[r] == "R")
                                {
                                    bolvanka[forHead] = " ";
                                    forHead++;
                                    if (forHead < 0 || forHead >= tape.Count)
                                        check = false;
                                    else
                                        bolvanka[forHead] = "^";

                                }

                                if (position[r] == "L")
                                {
                                    bolvanka[forHead] = " ";
                                    forHead--;
                                    if (forHead < 0 || forHead >= tape.Count)
                                        check = false;
                                    // else
                                    if (forHead >= 0 & forHead < tape.Count)
                                        bolvanka[forHead] = "^";

                                }
                                if (forHead < 0 || forHead >= tape.Count)
                                    check = false;
                                state = State2[r];//
                                                  //if (state_3 == "X")
                                                  //  break;
                                r = -1;

                            }
                        }
                    //else
                    //{
                    r++;
                    if (forHead < 0 || forHead >= tape.Count)
                        check = false;
                    if (check == false)
                        r = 2554;
                    Console.WriteLine("---------------FILE 1 STARTS:-------------------");
                    Console.WriteLine("After changing:" + "\n");
                    Console.WriteLine(string.Join("", tape));//показывает на каком моменте сейчас находится 
                    Console.WriteLine(string.Join("", bolvanka));
                    Console.WriteLine("tape state: " + state);
                    Console.WriteLine("--------------------FILE 1 ENDS------------------");
                    Thread.Sleep(100);

                }

                if (check == false)
                {
                    Console.WriteLine("---------------FILE 1 START:-------------------");
                    Console.WriteLine("Machine stopped with this result:");

                    Console.WriteLine(string.Join("", tape));
                    Console.WriteLine(string.Join("", bolvanka));
                    Console.WriteLine("---------------FILE 1 ENDS:-------------------");
                    Thread.Sleep(100);

                }


                //if (forHead > tape.Count || forHead < 0 || state == "X") //прерывает цикл
                //    break;

                if (r_2 < State1_2.Count) //количество правил равно 5
                {
                    if (forHead_2 > 0 || forHead_2 < tape_2.Count)
                        if (state_2 == State1_2[r_2])
                        {
                            if (tape_2[forHead_2] == original_2[r_2])
                            {

                                if (changeTo_2[r_2] != "*")
                                    tape_2[forHead_2] = changeTo_2[r_2];

                                //  if (forHead_3 < 0 || forHead_3 >= tape_3.Count)
                                // Console.WriteLine(string.Join("", tape_3));
                                if (position_2[r_2] == "R")
                                {
                                    bolvanka_2[forHead_2] = " ";
                                    forHead_2++;
                                    if (forHead_2 < 0 || forHead_2 >= tape_2.Count)
                                        check_2 = false;
                                    else
                                        bolvanka_2[forHead_2] = "^";

                                }

                                if (position_2[r_2] == "L")
                                {
                                    bolvanka_2[forHead_2] = " ";
                                    forHead_2--;
                                    if (forHead_2 < 0 || forHead_2 >= tape_2.Count)
                                        check_2 = false;
                                    // else
                                    if (forHead_2 >= 0 & forHead_2 < tape_2.Count)
                                        bolvanka_2[forHead_2] = "^";

                                }
                                if (forHead_2 < 0 || forHead_2 >= tape_2.Count)
                                    check_2 = false;
                                state_2 = State2_2[r_2];//
                                                        //if (state_3 == "X")
                                                        //  break;
                                r_2 = -1;

                            }
                        }
                    //else
                    //{
                    r_2++;
                    if (forHead_2 < 0 || forHead_2 >= tape_2.Count)
                        check_2 = false;
                    if (check_2 == false)
                        r_2 = 2554;
                    Console.WriteLine("---------------FILE 2 STARTS:-------------------");
                    Console.WriteLine("After changing:" + "\n");
                    Console.WriteLine(string.Join("", tape_2));//показывает на каком моменте сейчас находится 
                    Console.WriteLine(string.Join("", bolvanka_2));
                    Console.WriteLine("tape state: " + state_2);
                    Console.WriteLine("--------------------FILE 2 ENDS------------------");
                    Thread.Sleep(100);
                }

                        if (r_3 < State1_3.Count) //количество правил равно 5
                        {
                            if (forHead_3 > 0 || forHead_3 < tape_3.Count)
                                if (state_3 == State1_3[r_3])
                                {
                                    if (tape_3[forHead_3] == original_3[r_3])
                                    {

                                        if (changeTo_3[r_3] != "*")
                                            tape_3[forHead_3] = changeTo_3[r_3];

                                        //  if (forHead_3 < 0 || forHead_3 >= tape_3.Count)
                                        // Console.WriteLine(string.Join("", tape_3));
                                        if (position_3[r_3] == "R")
                                        {
                                            bolvanka_3[forHead_3] = " ";
                                            forHead_3++;
                                            if (forHead_3 < 0 || forHead_3 >= tape_3.Count)
                                                check_3 = false;
                                            else
                                                bolvanka_3[forHead_3] = "^";

                                        }

                                        if (position_3[r_3] == "L")
                                        {
                                            bolvanka_3[forHead_3] = " ";
                                            forHead_3--;
                                            if (forHead_3 < 0 || forHead_3 >= tape_3.Count)
                                                check_3 = false;
                                            // else
                                            if (forHead_3 >= 0 & forHead_3 < tape_3.Count)
                                                bolvanka_3[forHead_3] = "^";

                                        }
                                        if (forHead_3 < 0 || forHead_3 >= tape_3.Count)
                                            check_3 = false;
                                        state_3 = State2_3[r_3];//
                                                                //if (state_3 == "X")
                                                                //  break;
                                        r_3 = -1;

                                    }
                                }
                            //else
                            //{
                            r_3++;
                            if (forHead_3 < 0 || forHead_3 >= tape_3.Count)
                                check_3 = false;
                            if (check_3 == false)
                                r_3 = 2554;
                            Console.WriteLine("---------------FILE 3 STARTS:-------------------");
                            Console.WriteLine("After changing:" + "\n");
                            Console.WriteLine(string.Join("", tape_3));//показывает на каком моменте сейчас находится 
                            Console.WriteLine(string.Join("", bolvanka_3));
                            Console.WriteLine("tape state: " + state_3);
                            Console.WriteLine("--------------------FILE 3 ENDS------------------");
                            Thread.Sleep(100);


                            //if (forHead_3 > tape_3.Count || forHead_3 < 0 || r_3 > State1_3.Count) //прерывает цикл
                            // break;
                            //}


                        }

                        if (check_3 == false)
                        {
                            Console.WriteLine("---------------FILE 3 START:-------------------");
                            Console.WriteLine("Machine stopped with this result:");

                            Console.WriteLine(string.Join("", tape_3));
                            Console.WriteLine(string.Join("", bolvanka_3));
                            Console.WriteLine("---------------FILE 3 ENDS:-------------------");
                            Thread.Sleep(100);

                        }

                        if (r_4 < State1_4.Count) //количество правил равно 5
                        {
                            if (forHead_4 > 0 || forHead_4 < tape_4.Count)
                                if (state_4 == State1_4[r_4])
                                {
                                    if (tape_4[forHead_4] == original_4[r_4])
                                    {

                                        if (changeTo_4[r_4] != "*")
                                            tape_4[forHead_4] = changeTo_4[r_4];

                                        //  if (forHead_3 < 0 || forHead_3 >= tape_3.Count)
                                        // Console.WriteLine(string.Join("", tape_3));
                                        if (position_4[r_4] == "R")
                                        {
                                            bolvanka_4[forHead_4] = " ";
                                            forHead_4++;
                                            if (forHead_4 < 0 || forHead_4 >= tape_4.Count)
                                                check_4 = false;
                                            else
                                                bolvanka_4[forHead_4] = "^";

                                        }

                                        if (position_4[r_4] == "L")
                                        {
                                            bolvanka_4[forHead_4] = " ";
                                            forHead_4--;
                                            if (forHead_4 < 0 || forHead_4 >= tape_4.Count)
                                                check_4 = false;
                                            // else
                                            if (forHead_4 >= 0 & forHead_4 < tape_4.Count)
                                                bolvanka_4[forHead_4] = "^";

                                        }
                                        if (forHead_4 < 0 || forHead_4 >= tape_4.Count)
                                            check_4 = false;
                                        state_4 = State2_4[r_4];//
                                                                //if (state_3 == "X")
                                                                //  break;
                                        r_4 = -1;

                                    }
                                }
                            //else
                            //{
                            r_4++;
                            if (forHead_4 < 0 || forHead_4 >= tape_4.Count)
                                check_4 = false;
                            if (check_4 == false)
                                r_4 = 2554;
                            Console.WriteLine("---------------FILE 4 STARTS:-------------------");
                            Console.WriteLine("After changing:" + "\n");
                            Console.WriteLine(string.Join("", tape_4));//показывает на каком моменте сейчас находится 
                            Console.WriteLine(string.Join("", bolvanka_4));
                            Console.WriteLine("tape state: " + state_4);
                            Console.WriteLine("--------------------FILE 4 ENDS------------------");
                            Thread.Sleep(100);


                        }

                        if (check_4 == false)
                        {
                            Console.WriteLine("---------------FILE 4 START:-------------------");
                            Console.WriteLine("Machine stopped with this result:");

                            Console.WriteLine(string.Join("", tape_4));
                            Console.WriteLine(string.Join("", bolvanka_4));
                            Console.WriteLine("---------------FILE 4 ENDS:-------------------");
                            Thread.Sleep(100);

                        }
                Thread.Sleep(400);
                        Console.Clear();
                        if (check_3 == false & check_4 == false & check_2==false &check==false)
                            break;


                    }


                    Console.WriteLine("Done!");


                }


            }
        }
    
