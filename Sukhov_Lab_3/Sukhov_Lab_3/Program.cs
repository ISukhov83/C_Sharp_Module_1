using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class calculator
    {
        public Int16 Operation_Type = 1;
        private string C_String = "0";
        private decimal A_Decimal = 0;
        private decimal B_Decimal = 0;
        public string Calc_Data(string A_String = "", string B_String = "")
        {
            if (decimal.TryParse(A_String, out A_Decimal) & decimal.TryParse(B_String, out B_Decimal))
            {
                A_Decimal = decimal.Parse(A_String);
                B_Decimal = decimal.Parse(B_String);
                switch (Operation_Type)
                {
                    case 1:
                        Console.WriteLine("Multiplication A*B");
                        C_String = A_Decimal.ToString() + "*" + B_Decimal.ToString() + "=" + (A_Decimal * B_Decimal).ToString();
                        break;
                    case 2:
                        if (B_Decimal != 0)
                        {
                            Console.WriteLine("Divide A/B");
                            C_String = A_Decimal.ToString() + "/" + B_Decimal.ToString() + "=" + (A_Decimal / B_Decimal).ToString();
                        }
                        else
                            C_String = "Division by zero!!";
                        break;
                    case 3:
                        Console.WriteLine("Addition A+B");
                        C_String = A_Decimal.ToString() + "+" + B_Decimal.ToString() + "=" + (A_Decimal + B_Decimal).ToString();
                        break;
                    case 4:
                        Console.WriteLine("Substuction A-B");
                        C_String = A_Decimal.ToString() + "-" + B_Decimal.ToString() + "=" + (A_Decimal - B_Decimal).ToString();
                        break;
                    case 5:
                        //просить по баг
                        //C_String = ((Int32.Parse(A_Decimal) ^ Int32.Parse(B_Decimal)));
                        break;
                }
            }
            else
                C_String = "Wrong number format!!!!!";
            return C_String;
        }

    }

    class Guess_of_Number
    {
        private Int16 Inserted_number = 0;
        private string inserted_number_string = "";
        public void Guess_of_number(Int32 My_Random_Number = 0)
        {
            while (Inserted_number != My_Random_Number)
            {
                Console.Write("write the number:");
                inserted_number_string = Console.ReadLine();
                if (Int16.TryParse(inserted_number_string, out Inserted_number))
                {
                    Inserted_number = Int16.Parse(inserted_number_string);
                    if (Inserted_number < My_Random_Number)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine(Inserted_number.ToString() + " To low!");
                    }
                    if (Inserted_number > My_Random_Number)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine(Inserted_number.ToString() + " To high!");
                    }
                    if (Inserted_number == My_Random_Number)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Congratulation!!");
                    }

                }
                else Console.WriteLine("Wrong number format!!!!!");

            }



        }
    }

    class Factorial
    {
        private Int64 Factorial_Int = 1;
        private Int64 My_Number = 0;
        public string Factorial_Calc(string String_number = "")
        {
            if (Int64.TryParse(String_number, out My_Number))
            {
                Factorial_Int = 1;
                My_Number = Int64.Parse(String_number);
                for (Int64 i = 1; i <= Int64.Parse(String_number); i++) //RV: You've already parsed this string and saved the value into variable. No need to parse it in every loop iteration. Use the variable
                {
                    if ((Factorial_Int * i) < Int64.MaxValue) 
                        Factorial_Int = Factorial_Int * i;
                    else Console.WriteLine("Переполнение числа int64"); //RV: Will it ever enter this part?

                }
                return "Factorial of number " + String_number + "=" + Factorial_Int.ToString();
            }
            return "Wrong number format!!";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Int16 Main_Menu_position = 1;
            calculator My_Calculator = new calculator();
            Factorial My_Factorial_Calc = new Factorial();
            Random My_Random_Number = new Random();
            Guess_of_Number Guess_of_Number = new Guess_of_Number();
            string String_number_for_factorial = "";
            string A_String = "";
            string B_String = "";
            Console.WriteLine("Please select type of:");
            Console.WriteLine("1. Puzzle \"The farmer, wolf, goat and cabbage\""); // RV: Don't see the implementation of this part
            Console.WriteLine("2. Simple calculator");
            Console.WriteLine("3. The factorial of the number");
            Console.WriteLine("4. Guess the number");
            Console.Write("Write menu NUMBER and thn press enter:");

            Main_Menu_position = Int16.Parse(Console.ReadLine());

            switch (Main_Menu_position)
            {
                case 2:
                    Console.Clear();
                    Console.WriteLine("Simple calculator");
                    Console.WriteLine("Please select operation type");
                    Console.WriteLine("1. Multiplication  A*B");
                    Console.WriteLine("2. Divide          A/B");
                    Console.WriteLine("3. Addition        A+B");
                    Console.WriteLine("4. Substuction     A-B");
                    Console.WriteLine("5. Substuction     A^B");
                    Console.Write("Write menu NUMBER and thn press enter:");
                    My_Calculator.Operation_Type = Int16.Parse(Console.ReadLine());
                    Console.Write("Pleas set the A:");
                    A_String = Console.ReadLine();
                    Console.Write("Pleas set the B:");
                    B_String = Console.ReadLine();
                    Console.WriteLine("");
                    Console.WriteLine(My_Calculator.Calc_Data(A_String, B_String));
                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine("Fatorial calculation");
                    Console.Write("Write menu NUMBER and thn press enter:");
                    String_number_for_factorial = Console.ReadLine();
                    Console.WriteLine(My_Factorial_Calc.Factorial_Calc(String_number_for_factorial));
                    break;
                case 4:
                    Console.Clear();
                    Console.WriteLine("Guess the number, between 1 and 100");
                    Guess_of_Number.Guess_of_number(My_Random_Number.Next(1, 100));
                    break;
            }

            Console.ReadLine();
        }
    }
}
