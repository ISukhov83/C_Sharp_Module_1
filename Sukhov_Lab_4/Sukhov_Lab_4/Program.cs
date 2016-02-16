using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sukhov_Lab_4
{
    struct Computer_Configurations
    {
        public Int16 Configuration_ID; //RV: Enum should be used insted of Configuration_ID and Configuration_Name
        public String Configuration_Name;
        public Int16 Cores_Count;
        public decimal CPU_Freqvency;
        public Int16 RAM;
        public Int16 HDD_Capacity;

    }

    class Program
    {
        static void Main(string[] args)
        {
            Computer_Configurations Desktop = new Computer_Configurations();
            Computer_Configurations Laptop = new Computer_Configurations();
            Computer_Configurations Server = new Computer_Configurations();
            /*Desktop configuration*/
            Desktop.Configuration_ID = 1;
            Desktop.Configuration_Name = "Desktop";
            Desktop.Cores_Count = 4;
            Desktop.CPU_Freqvency = 2.5M;
            Desktop.RAM = 6;
            Desktop.HDD_Capacity = 500;
            /*Laptop configuration*/
            Laptop.Configuration_ID = 2;
            Laptop.Configuration_Name = "Laptop";
            Laptop.Cores_Count = 2;
            Laptop.CPU_Freqvency = 1.7M;
            Laptop.RAM = 4;
            Laptop.HDD_Capacity = 250;
            /*Server configuration*/
            Server.Configuration_ID = 3;
            Server.Configuration_Name = "Server";
            Server.Cores_Count = 8;
            Server.CPU_Freqvency = 3M;
            Server.RAM = 16;
            Server.HDD_Capacity = 2048;

<<<<<<< HEAD
            Computer_Configurations[][] Departments_Computers = new Computer_Configurations[4][];
=======
            //RV: This array must contain real computer objects. Not integers.
            Int16[][] Departments_Computers = new Int16[4][];
>>>>>>> origin/master
            /*вносим данныев масив компьютеров по отделам*/
            Departments_Computers[0] = new Computer_Configurations[5] { Desktop, Desktop, Laptop, Laptop, Server };
            Departments_Computers[1] = new Computer_Configurations[3] { Laptop, Laptop, Laptop };
            Departments_Computers[2] = new Computer_Configurations[5] { Desktop, Desktop, Desktop, Laptop, Laptop };
            Departments_Computers[3] = new Computer_Configurations[4] { Desktop, Desktop, Server, Server };

            /*работа поиска ответов лабы*/
            /*1 общее количество компьютеров*/
            Console.WriteLine("TASK 1");
            Int32 Computers_Count = 0;
            for(Int32 i=1; i<= Departments_Computers.GetLength(0); i++)
            {
                for(Int32 j=1; j<= Departments_Computers[i-1].GetLength(0); j++)
                {
                    //Console.WriteLine("i="+i+" j="+j +" value="+Departments_Computers[i-1][j-1]);
                    Computers_Count = Computers_Count+1;
                }
            }
            Console.WriteLine("Total computers count="+Computers_Count.ToString());
            /*2 вывести компьютеры с максимальной HDD*/
            /*цикл поиска максимального значения HDD по всему масиву*/
            Console.WriteLine("");
            Console.WriteLine("TASK 2");
            Int16 Max_HDD_Capacity = 0;
            decimal Min_CPU_Frequncy = 1000;
            //RV: This is jagged array. No need to call GetLength(0). Just use Length property.
            for (Int32 i = 1; i <= Departments_Computers.GetLength(0); i++)
            {                
                //RV: Use < operator insted of <= and start index from 0 istead of 1. You will not need to substruct 1 from indexes
                for (Int32 j = 1; j <= Departments_Computers[i - 1].GetLength(0); j++) 
                {
                    //Console.WriteLine(Departments_Computers[i - 1][j - 1]);
                    if(Departments_Computers[i - 1][j - 1].HDD_Capacity>= Max_HDD_Capacity)
                        Max_HDD_Capacity = Departments_Computers[i - 1][j - 1].HDD_Capacity;
                    if(Departments_Computers[i - 1][j - 1].CPU_Freqvency< Min_CPU_Frequncy)
                        Min_CPU_Frequncy = Departments_Computers[i - 1][j - 1].CPU_Freqvency;
                }
            }
            Console.WriteLine("Maximun HHD capacity is=" + Max_HDD_Capacity.ToString()+" Mb");
            /*Выводим список компьютеров с максимальным HDD*/
            for (Int32 i = 1; i <= Departments_Computers.GetLength(0); i++)
            {
                for (Int32 j = 1; j <= Departments_Computers[i - 1].GetLength(0); j++)
                {
                   if(Departments_Computers[i - 1][j - 1].HDD_Capacity== Max_HDD_Capacity)
                        Console.WriteLine("Departament №" + i + " Computer №" + j + " Configuration: " +
                                    Departments_Computers[i - 1][j - 1].Configuration_Name + ", " + Departments_Computers[i - 1][j - 1].Cores_Count + " Cores, " +
                                    Departments_Computers[i - 1][j - 1].CPU_Freqvency + " HGz CPU, " + Departments_Computers[i - 1][j - 1].RAM + " GB RAM, " + Departments_Computers[i - 1][j - 1].HDD_Capacity + " Mb HDD");
                }
            }
            /*3 вывести компьютеры с с минимальным CPU*/
            /*цикл поиска максимального значения HDD по всему масиву*/
            Console.WriteLine("");
            Console.WriteLine("TASK 3");
            Console.WriteLine("Mminimum CUP Frequncy is=" + Min_CPU_Frequncy.ToString()+ " HGz");
            /*Выводим список компьютеров с минимальным CPU*/
            for (Int32 i = 1; i <= Departments_Computers.GetLength(0); i++)
            {
                for (Int32 j = 1; j <= Departments_Computers[i - 1].GetLength(0); j++)
                {
                    //Console.WriteLine(Departments_Computers[i - 1][j - 1]);
                    if (Departments_Computers[i - 1][j - 1].CPU_Freqvency == Min_CPU_Frequncy)
                        Console.WriteLine("Departament №" + i + " Computer №" + j + " Configuration: " +
                                    Departments_Computers[i - 1][j - 1].Configuration_Name + ", " + Departments_Computers[i - 1][j - 1].Cores_Count + " Cores, " +
                                    Departments_Computers[i - 1][j - 1].CPU_Freqvency + " HGz CPU, " + Departments_Computers[i - 1][j - 1].RAM + " GB RAM, " + Departments_Computers[i - 1][j - 1].HDD_Capacity + " Mb HDD");

                }
            }

            /*Task 4*/
            Console.WriteLine("");
            Console.WriteLine("TASK 4");
            Desktop.CPU_Freqvency = 3.5M;

            Console.ReadLine();
        }
    }
}
