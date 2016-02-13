using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sukhov_Lab_4
{
    struct Computer_Configurations
    {
        public Int16 Configuration_ID;
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

            Int16[][] Departments_Computers = new Int16[4][];
            /*вносим данныев масив компьютеров по отделам*/
            Departments_Computers[0] = new Int16[5] { 1, 1, 2, 2, 3 };
            Departments_Computers[1] = new Int16[3] { 2,2,2};
            Departments_Computers[2] = new Int16[5] { 1,1,1,2,2};
            Departments_Computers[3] = new Int16[4] { 1, 1,3,3 };

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
            for (Int32 i = 1; i <= Departments_Computers.GetLength(0); i++)
            {
                for (Int32 j = 1; j <= Departments_Computers[i - 1].GetLength(0); j++)
                {
                    //Console.WriteLine(Departments_Computers[i - 1][j - 1]);
                    switch (Departments_Computers[i - 1][j - 1])
                    {
                        case 1:
                            if (Desktop.HDD_Capacity > Max_HDD_Capacity)
                                Max_HDD_Capacity = Desktop.HDD_Capacity;
                            if (Desktop.CPU_Freqvency < Min_CPU_Frequncy)
                                Min_CPU_Frequncy = Desktop.CPU_Freqvency;
                            break;
                        case 2:
                            if (Laptop.HDD_Capacity > Max_HDD_Capacity)
                                Max_HDD_Capacity = Laptop.HDD_Capacity;
                            if (Laptop.CPU_Freqvency < Min_CPU_Frequncy)
                                Min_CPU_Frequncy = Laptop.CPU_Freqvency;
                            break;
                        case 3:
                            if (Server.HDD_Capacity > Max_HDD_Capacity)
                                Max_HDD_Capacity = Server.HDD_Capacity;
                            if (Server.CPU_Freqvency < Min_CPU_Frequncy)
                                Min_CPU_Frequncy = Server.CPU_Freqvency;
                            break;
                        default:
                            Max_HDD_Capacity = 0;
                            Min_CPU_Frequncy = 1000;
                            break;
                    }
                }
            }
            Console.WriteLine("Maximun HHD capacity is=" + Max_HDD_Capacity.ToString()+" Mb");
            /*Выводим список компьютеров с максимальным HDD*/
            for (Int32 i = 1; i <= Departments_Computers.GetLength(0); i++)
            {
                for (Int32 j = 1; j <= Departments_Computers[i - 1].GetLength(0); j++)
                {
                    //Console.WriteLine(Departments_Computers[i - 1][j - 1]);
                    switch (Departments_Computers[i - 1][j - 1])
                    {
                        case 1:
                            if (Desktop.HDD_Capacity == Max_HDD_Capacity)
                                Console.WriteLine("Departament №" + i + " Computer №" + j + " Configuration: "+ 
                                    Desktop.Configuration_Name+", "+ Desktop.Cores_Count+" Cores, "+
                                    Desktop.CPU_Freqvency+" HGz CPU, "+ Desktop.RAM+" GB RAM, "+ Desktop.HDD_Capacity+" Mb HDD");
                            break;
                        case 2:
                            if (Laptop.HDD_Capacity == Max_HDD_Capacity)
                                Console.WriteLine("Departament №" + i + " Computer №" + j + " Configuration: " +
                                    Laptop.Configuration_Name + ", " + Laptop.Cores_Count + " Cores, " +
                                    Laptop.CPU_Freqvency + " HGz CPU, " + Laptop.RAM + " GB RAM, " + Laptop.HDD_Capacity + " Mb HDD");
                            break;
                        case 3:
                            if (Server.HDD_Capacity == Max_HDD_Capacity)
                                Console.WriteLine("Departament №" + i + " Computer №" + j + " Configuration: " +
                                    Server.Configuration_Name + ", " + Server.Cores_Count + " Cores, " +
                                    Server.CPU_Freqvency + " HGz CPU, " + Server.RAM + " GB RAM, " + Server.HDD_Capacity + " Mb HDD");
                            break;
                        default:
                            Console.WriteLine("No Computers!");
                            break;
                    }
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
                    switch (Departments_Computers[i - 1][j - 1])
                    {
                        case 1:
                            if (Desktop.CPU_Freqvency == Min_CPU_Frequncy)
                                Console.WriteLine("Departament №" + i + " Computer №" + j + " Configuration: " +
                                    Desktop.Configuration_Name + ", " + Desktop.Cores_Count + " Cores, " +
                                    Desktop.CPU_Freqvency + " HGz CPU, " + Desktop.RAM + " GB RAM, " + Desktop.HDD_Capacity + " Mb HDD");
                            break;
                        case 2:
                            if (Laptop.CPU_Freqvency == Min_CPU_Frequncy)
                                Console.WriteLine("Departament №" + i + " Computer №" + j + " Configuration: " +
                                    Laptop.Configuration_Name + ", " + Laptop.Cores_Count + " Cores, " +
                                    Laptop.CPU_Freqvency + " HGz CPU, " + Laptop.RAM + " GB RAM, " + Laptop.HDD_Capacity + " Mb HDD");
                            break;
                        case 3:
                            if (Server.CPU_Freqvency == Min_CPU_Frequncy)
                                Console.WriteLine("Departament №" + i + " Computer №" + j + " Configuration: " +
                                    Server.Configuration_Name + ", " + Server.Cores_Count + " Cores, " +
                                    Server.CPU_Freqvency + " HGz CPU, " + Server.RAM + " GB RAM, " + Server.HDD_Capacity + " Mb HDD");
                            break;
                        default:
                            Console.WriteLine("No Computers!");
                            break;
                    }
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
