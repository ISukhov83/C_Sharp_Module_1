using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Treading; not working

namespace Sukhov_Lab_5
{
    class Program
    {
        static void Main(string[] args)
        {
            Int32 Menu_Position = 1;
            Int32 A = 0;
            Int32 B = 0;
            Int32 Binar_Length = 1;
            /*прописываем пункты главного меню*/
            String Abs_String="";
            Console.WriteLine("Select operation type");
            Console.WriteLine("1. Absolute value of the difference between two numbers written as a unary string");
            Console.WriteLine("2. Record of the number as a binary string");
            Console.WriteLine("3. Realize Morse code as sounds");
            Console.Write("Put menu position number: ");
            Menu_Position = Int32.Parse(Console.ReadLine());
            /*Задача 1*/
            if(Menu_Position==1)
            {
                Console.WriteLine("Absolute value of the difference between two numbers written as a unary string");
                Console.Write("Set A:");
                A = Int32.Parse(Console.ReadLine());
                Console.Write("Set B:");
                B = Int32.Parse(Console.ReadLine());
                for (Int32 i = 1; i <= A; i++)
                    Abs_String = Abs_String + "1";
                Abs_String = Abs_String + "#";
                for(Int32 j=1; j<= B; j++)
                    Abs_String = Abs_String + "1";
                Console.WriteLine(Abs_String);
                if (A > B)
                    A = B;
                for(Int32 k=1; k<= A; k++)
                {
                    Abs_String = Abs_String.Substring(1, Abs_String.Length - 2);
                    for (Int32 n = 1; n <= k; n++)
                        Console.Write(" ");
                    Console.WriteLine(Abs_String);
                }

            }
            /*Задача 2*/
            if (Menu_Position == 2)
            {
                Console.Clear();
                Console.WriteLine("Record of the number as a binary string\" description:");
                Console.Write("Enter positive integer: ");
                A = Int32.Parse(Console.ReadLine());
                /*вычисляем длинну битовой строки*/
                for (Int32 i = 0; i <= 31; i++)
                {
                    if(A< Math.Pow(2, i))
                    {
                       // Console.WriteLine("2^"+i+": " + Math.Pow(2 , i).ToString());
                        Binar_Length = i;
                        break;
                    }
                }
                Int32[] Bit_Array = new Int32[Binar_Length + 1];
                Console.WriteLine("Binar Length: " + Binar_Length);
                Console.Write("Binar string: ");
                /*цикл построения битовой строки и масива*/
                for (Int32 j= Binar_Length; j>=0; j--)
                {
                    if (A > Math.Pow(2, j))
                    {
                        Bit_Array[Binar_Length-j] = 1;
                        A = A - (int)Math.Pow(2, j);
                        Console.Write("1");
                    }
                    else
                    {
                        Bit_Array[Binar_Length - j] = 0;
                        Console.Write("0");
                    }
                }

            }
            /*Задача 3*/
            if (Menu_Position == 3)
            {
                for(Int32 i=1; i<=100; i++)
                {
                    //Thread.Sleep(500);
                    //Console.WriteLine(i);
                    //Console.Beep(30+(10*i), 200);
                    if (i % 2 == 0)
                    {
                        
                        Console.Beep(1000, 200);
                        Console.Beep(1000, 200);
                        Console.Beep(1000, 200);
                    }

                    if (i % 2 != 0)
                    {
                        Console.Beep(1000, 800);
                        Console.Beep(1000, 800);
                        Console.Beep(1000, 800);
                    }
                }

            }

                Console.ReadLine();

        }
    }
}
