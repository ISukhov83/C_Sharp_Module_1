using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport_1_Console
{
    enum Arrival_Status_types
    {
        Arrived=1,
        Unknown=2,
        Canceled=3,
        Delayed=4,
        In_Flight=5
    }
    public class Main_Menu                                          /*скласс описывает обьект "главное меню"*/
    {
        public Int16 Menu_Position_Number = 1;                      /*переменная указывает номер пункта меню, который будет активным и выделен цветом*/
        public void Show_Main_Menu()
        {
            
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            /*Заполняем текстовый перечень пунктов меню*/
            Console.WriteLine("Airport panel. The main menu");
            Console.WriteLine();
            Console.WriteLine("Please select action type");
            Console.WriteLine("To navigate use keys up/down arrows and then ENTER. Press fast key \"E\" to Exit");
            Console.WriteLine();
            Console.WriteLine("1. Show Arrivals");
            Console.WriteLine("2. Show Departures");
            Console.WriteLine("3. Add new flygth to Arrivals");
            Console.WriteLine("4. Add new flyght to Departures");
            Console.WriteLine("5. Edit Arrivals");
            Console.WriteLine("6. Edit Departures");
            Console.WriteLine("7. Exit");
            Console.WriteLine("8. EVACUATION!!");
            /*Проверяем выход переменной пункта меню за диапазон 1-8*/
            if (Menu_Position_Number < 1)
                Menu_Position_Number = 1;
            if (Menu_Position_Number > 8)
                Menu_Position_Number = 8;
            /*Устанавливаем курсор на указанный пункт меню*/
            Console.SetCursorPosition(3, Menu_Position_Number+4);
            /*Задаем желтый цвет заливки выбранного пункта меню*/
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Black;
            switch(Menu_Position_Number)
            {
                case 1:
                    Console.Write("Show Arrivals");
                    break;
                case 2:
                    Console.Write("Show Departures");
                    break;
                case 3:
                    Console.Write("Add new flygth to Arrivals");
                    break;
                case 4:
                    Console.Write("Add new flyght to Departures");
                    break;
                case 5:
                    Console.Write("Edit Arrivals");
                    break;
                case 6:
                    Console.Write("Edit Departures");
                    break;
                case 7:
                    Console.Write("Exit");
                    break;
                case 8:
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write("EVACUATION!!");
                    break;
            }
            Console.SetCursorPosition(0, Menu_Position_Number + 4);
            /*Возращаем черную заливку экрана*/
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }
    }

    public class Arrivals                                           /*Класс описывает обьекты "прибытия"*/
    {
        public Int16 Arrival_Table_Collumn_Num = 1;                 /*Переменная содержит значение выбранной колонки в таблице*/
        private ConsoleKeyInfo Arrival_Console_keyInfo;
        private string Arrival_Table_Column_Name;
        public void Show_Arrival_Table_Head()                       /*Метод прорисовывает заглавную строку таблицы прибытий*/
        {
            Console.Clear();
            //Console.WriteLine("┌;┐;└;┘;┬;┴;├;┼;┤;─;│");           /*справочник символов прорисовки таблицы*/
            Console.WriteLine();
            Console.WriteLine("ARRIVALS     Use LEFT/RIGHT ARROWS to column navigate, and UP/DOWN ARROWS to sort arrives");
            /*Прорисовываем загланую часть таблицы*/
            Console.WriteLine("  ┌───────────────┬───────────┬──────────────┬──────────────────────┬──────────┬───────────────┬──────┐");
            Console.WriteLine("  │ Flight number │  Airline  │ Arrival time │ City/port of arrival │ Terminal │ Flight status │ Gate │");
            Console.WriteLine("  ├───────────────┼───────────┼──────────────┼──────────────────────┼──────────┼───────────────┼──────┤");
            /*Проверяем Arrival_Table_Collumn_Num на выход из диапазона 1-7*/
            if (Arrival_Table_Collumn_Num < 1)
                Arrival_Table_Collumn_Num = 1;
            if (Arrival_Table_Collumn_Num > 7)
                Arrival_Table_Collumn_Num = 7;
            /*Задаем желтый цвет заливки выбранного пункта меню*/
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Black;
            /*Активируем заливкой выбранную колонку таблицы прибытий*/
            switch (Arrival_Table_Collumn_Num)
            {
                case 1:
                    Console.SetCursorPosition(4,3);
                    Console.Write("Flight number");
                    break;
                case 2:
                    Console.SetCursorPosition(21, 3);
                    Console.Write("Airline");
                    break;
               case 3:
                    Console.SetCursorPosition(32, 3);
                    Console.Write("Arrival time");
                    break;
               case 4:
                    Console.SetCursorPosition(47, 3);
                    Console.Write("City/port of arrival");
                    break;
                case 5:
                    Console.SetCursorPosition(70, 3);
                    Console.Write("Terminal");
                    break;
                case 6:
                    Console.SetCursorPosition(81, 3);
                    Console.Write("Flight status");
                    break;
                case 7:
                    Console.SetCursorPosition(97, 3);
                    Console.Write("Gate");
                    break;
            }
            /*Возращаем курсор и черную заливку экрана*/
            Console.SetCursorPosition(0, 5);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }
        /*Метод прорисоки нижней части таблицы*/
        public void Show_Arrival_Table_End()
        {
            Console.WriteLine("  └───────────────┴───────────┴──────────────┴──────────────────────┴──────────┴───────────────┴──────┘");
            Console.WriteLine();
            Console.WriteLine("Use key \"E\" to exit in main menu");
        }
        /*Метод прорисовки части таблицы с данными по прилетам*/
        private string[] Arrival_bufer_Array_for_Sort = new string[7];         /*создаем масив-буфер обмена для сортироваки масива по прибытиям*/
        public void Show_Arrival_Table_Data(string[,] Arrivals_Array_for_Table, Int16 Arrivals_Column_num_to_Sort = 1, string Sort_type="No sort")
        {
            /*цикл сортировки масива по ВОЗРАСТАНИЮ с данными по прилетам Arrivals_Array_for_Table по указанному номеру столбца */
            if(Sort_type=="ASC")
            for (Int16 m = 1; m <= 99; m++)
            {
                for (Int16 j = 1; j <= 99; j++)
                {
                    if (Arrivals_Array_for_Table[j, Arrivals_Column_num_to_Sort-1] != null)
                        if (Arrivals_Array_for_Table[j-1, Arrivals_Column_num_to_Sort - 1].CompareTo(Arrivals_Array_for_Table[j, Arrivals_Column_num_to_Sort - 1]) > 0)
                        {
                            for (Int16 k = 1; k <= 7; k++)
                            {
                                Arrival_bufer_Array_for_Sort[k - 1] = Arrivals_Array_for_Table[j, k - 1];
                                Arrivals_Array_for_Table[j, k - 1] = Arrivals_Array_for_Table[j - 1, k - 1];
                                Arrivals_Array_for_Table[j - 1, k - 1] = Arrival_bufer_Array_for_Sort[k - 1];
                            }
                        }
                    if (Arrivals_Array_for_Table[j, 1] == null)
                        break;
                }
                if (Arrivals_Array_for_Table[m, 1] == null)
                    break;
            };

            /*цикл сортировки масива по УБЫВАНИЮ с данными по прилетам Arrivals_Array_for_Table по указанному номеру столбца */
            if (Sort_type == "DESC")
                for (Int16 m = 1; m <= 99; m++)
                {
                    for (Int16 j = 1; j <= 99; j++)
                    {
                        if (Arrivals_Array_for_Table[j, Arrivals_Column_num_to_Sort - 1] != null)
                            if (Arrivals_Array_for_Table[j, Arrivals_Column_num_to_Sort - 1].CompareTo(Arrivals_Array_for_Table[j-1, Arrivals_Column_num_to_Sort - 1]) > 0)
                            {
                                for (Int16 k = 1; k <= 7; k++)
                                {
                                    Arrival_bufer_Array_for_Sort[k - 1] = Arrivals_Array_for_Table[j, k - 1];
                                    Arrivals_Array_for_Table[j, k - 1] = Arrivals_Array_for_Table[j - 1, k - 1];
                                    Arrivals_Array_for_Table[j - 1, k - 1] = Arrival_bufer_Array_for_Sort[k - 1];
                                }
                            }
                        if (Arrivals_Array_for_Table[j, 1] == null)
                            break;
                    }
                    if (Arrivals_Array_for_Table[m, 1] == null)
                        break;
                };

            /*циклом прорисовываем строчки с данными по рейсам в таблице*/
            for (Int16 i=1; i<=100; i++)
            {
                Console.Write("  │     " + Arrivals_Array_for_Table[i-1, 0]);
                Console.SetCursorPosition(18, Console.CursorTop);
                Console.Write("│" + Arrivals_Array_for_Table[i - 1, 1]);
                Console.SetCursorPosition(30, Console.CursorTop);
                Console.Write("│    " + Arrivals_Array_for_Table[i - 1, 2]);
                Console.SetCursorPosition(45, Console.CursorTop);
                Console.Write("│" + Arrivals_Array_for_Table[i - 1, 3]);
                Console.SetCursorPosition(68, Console.CursorTop);
                Console.Write("│    " + Arrivals_Array_for_Table[i - 1, 4]);
                Console.SetCursorPosition(79, Console.CursorTop);
                Console.Write("│   ");
                /*закрашиваем цветом задержки и прибытия рейсов*/
                if (Arrivals_Array_for_Table[i - 1, 5] == "Delayed")
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                else if (Arrivals_Array_for_Table[i - 1, 5] == "Arrived")
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.Black;
                };
                Console.Write(Arrivals_Array_for_Table[i - 1, 5]);
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(95, Console.CursorTop);
                Console.Write("│  " + Arrivals_Array_for_Table[i - 1, 6]);
                Console.SetCursorPosition(102, Console.CursorTop);
                Console.WriteLine("│");
                /*если следующий елемент масив пустой- выходим из цикла*/
                if (Arrivals_Array_for_Table[i, 0] == null | Arrivals_Array_for_Table[i, 0] == "")
                    break;
            }
        }
        /*метод подготовки параметров фильтровки масива с данными*/
        public void Get_Filtering_Parameters()
        {
            switch(Arrival_Table_Collumn_Num)
            {
                case 1:
                    Arrival_Table_Column_Name = "Flight number";
                    break;
                case 2:
                    Arrival_Table_Column_Name = "Airline";
                    break;
                case 3:
                    Arrival_Table_Column_Name = "Arrival time";
                    break;
                case 4:
                    Arrival_Table_Column_Name = "City/port of arrival";
                    break;
                case 5:
                    Arrival_Table_Column_Name = "Terminal";
                    break;
                case 6:
                    Arrival_Table_Column_Name = "Flight status";
                    break;
                case 7:
                    Arrival_Table_Column_Name = "Gate";
                    break;
            };
            Console.WriteLine();
            Console.Write("Фильтрация данных по полю ");


        }
        /*Метод получения данных по новому прибытию*/
        private string[] New_Arrival_Array = new string[7];                        /**/
        private string Save_New_Arrival_Ind = "N";
        private Int32 Menu_number_Errival_type = 1;
        ConsoleKeyInfo Arrival_Type_Key_Info = new ConsoleKeyInfo();
        public string[] Arrivals_Add_New_Arrival()
        {
            Menu_number_Errival_type = 1;
            /*заполняем масив пустыми строками*/
            for (Int16 i=1; i<=7; i++)
            {
                New_Arrival_Array[i - 1] = "";
            }
            for (Int16 New_arrival_punkt_menu = 1; New_arrival_punkt_menu <= 7; New_arrival_punkt_menu++)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Clear();
                Console.WriteLine();
                /*прорисовываем таблицу*/
                Console.WriteLine("Add new arrival:");
                Console.WriteLine("┌─────────────────────┬──────────────┐");
                Console.WriteLine("│ Flight number       │              │");
                Console.WriteLine("├─────────────────────┼──────────────┤");
                Console.WriteLine("│ Airline             │              │");
                Console.WriteLine("├─────────────────────┼──────────────┤");
                Console.WriteLine("│ Arrival time        │              │");
                Console.WriteLine("├─────────────────────┼──────────────┤");
                Console.WriteLine("│ City/port of arrival│              │");
                Console.WriteLine("├─────────────────────┼──────────────┤");
                Console.WriteLine("│ Terminal            │              │");
                Console.WriteLine("├─────────────────────┼──────────────┤");
                Console.WriteLine("│ Flight status       │              │ Use LEFT/RIGHT ARROWS to select flight status");
                Console.WriteLine("├─────────────────────┼──────────────┤");
                Console.WriteLine("│ Gate                │              │");
                Console.WriteLine("└─────────────────────┴──────────────┘");
                Console.WriteLine();
                /*вносим в таблицу уже заполненные данные*/
                for (Int16 i = 1; i <= 7; i++)
                {
                    Console.SetCursorPosition(23, 1 + i * 2);
                    Console.Write(New_Arrival_Array[i - 1].ToString());
                }
                //Console.Write(New_Arrival_Array[New_arrival_punkt_menu-1]);
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.ForegroundColor = ConsoleColor.Black;
                /*устанавливаем курсор на необходимый пункт меню*/
                Console.SetCursorPosition(23, 1 + (New_arrival_punkt_menu * 2));
                /*вносим данные в масив*/
                if(New_arrival_punkt_menu!=6)
                    New_Arrival_Array[New_arrival_punkt_menu - 1] = Console.ReadLine().ToString();
                /*Проверяем корректность введенных данных*/
                TimeSpan Time_to_Try;
                Int32 int_to_try;
                switch(New_arrival_punkt_menu)
                {
                    case 1:
                        if(New_Arrival_Array[New_arrival_punkt_menu - 1].Length!=4)
                        {
                            New_Arrival_Array[New_arrival_punkt_menu - 1] = "";
                            Console.SetCursorPosition(38, 1 + (New_arrival_punkt_menu * 2));
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("Номер рейса должен состоять из 4-х символов");
                            Console.ForegroundColor = ConsoleColor.White;
                            New_arrival_punkt_menu = --New_arrival_punkt_menu;
                            Console.SetCursorPosition(23, 3 + (New_arrival_punkt_menu * 2));
                            Console.ReadKey();
                        };
                        break;
                    case 2:
                        if (New_Arrival_Array[New_arrival_punkt_menu - 1].Length > 12 | New_Arrival_Array[New_arrival_punkt_menu - 1].Length<3)
                        {
                            New_Arrival_Array[New_arrival_punkt_menu - 1] = "";
                            Console.SetCursorPosition(38, 1 + (New_arrival_punkt_menu * 2));
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("Название авиалиний должно содержать от 3-х до 12-ти символов");
                            Console.ForegroundColor = ConsoleColor.White;
                            New_arrival_punkt_menu = --New_arrival_punkt_menu;
                            Console.SetCursorPosition(23, 3 + (New_arrival_punkt_menu * 2));
                            Console.ReadKey();
                        };
                        break;
                    case 3:
                        if (!TimeSpan.TryParse(New_Arrival_Array[New_arrival_punkt_menu - 1], out Time_to_Try))
                        {
                            New_Arrival_Array[New_arrival_punkt_menu - 1] = "";
                            Console.SetCursorPosition(38, 1 + (New_arrival_punkt_menu * 2));
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("Поле должно содержать данные о времени, в формате: hh:mm");
                            Console.ForegroundColor = ConsoleColor.White;
                            New_arrival_punkt_menu = --New_arrival_punkt_menu;
                            Console.SetCursorPosition(23, 3 + (New_arrival_punkt_menu * 2));
                            Console.ReadKey();
                         };
                        break;
                    case 4:
                        if (New_Arrival_Array[New_arrival_punkt_menu - 1].Length > 12 | New_Arrival_Array[New_arrival_punkt_menu - 1].Length < 3)
                        {
                            New_Arrival_Array[New_arrival_punkt_menu - 1] = "";
                            Console.SetCursorPosition(38, 1 + (New_arrival_punkt_menu * 2));
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("Название должно содержать от 3-х до 12-ти символов");
                            Console.ForegroundColor = ConsoleColor.White;
                            New_arrival_punkt_menu = --New_arrival_punkt_menu;
                            Console.SetCursorPosition(23, 3 + (New_arrival_punkt_menu * 2));
                            Console.ReadKey();
                        };
                        break;
                    case 5:
                        if (New_Arrival_Array[New_arrival_punkt_menu - 1].Length !=1)
                        {
                            New_Arrival_Array[New_arrival_punkt_menu - 1] = "";
                            Console.SetCursorPosition(38, 1 + (New_arrival_punkt_menu * 2));
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("Идентефикатор терминала - один символ!");
                            Console.ForegroundColor = ConsoleColor.White;
                            New_arrival_punkt_menu = --New_arrival_punkt_menu;
                            Console.SetCursorPosition(23, 3 + (New_arrival_punkt_menu * 2));
                            Console.ReadKey();
                        };
                        break;
                    case 6:
                        while(true)
                        {
                            Console.WriteLine();
                            Console.SetCursorPosition(23, 1 + (New_arrival_punkt_menu * 2));
                            switch (Menu_number_Errival_type)
                            {
                                case 1:
                                    Console.WriteLine("Arrived   ");
                                    New_Arrival_Array[New_arrival_punkt_menu - 1] = "Arrived";
                                    break;
                                case 2:
                                    Console.WriteLine("Unknown   ");
                                    New_Arrival_Array[New_arrival_punkt_menu - 1] = "Unknown";
                                    break;
                                case 3:
                                    Console.WriteLine("Canceled  ");
                                    New_Arrival_Array[New_arrival_punkt_menu - 1] = "Canceled";
                                    break;
                                case 4:
                                    Console.WriteLine("Delayed    ");
                                    New_Arrival_Array[New_arrival_punkt_menu - 1] = "Delayed";
                                    break;
                                case 5:
                                    Console.WriteLine("In_Flight  ");
                                    New_Arrival_Array[New_arrival_punkt_menu - 1] = "In_Flight";
                                    break;
                                default:
                                    break;

                            }
                            Console.SetCursorPosition(23, 1 + (New_arrival_punkt_menu * 2));
                            Arrival_Type_Key_Info = Console.ReadKey();
                            if (Arrival_Type_Key_Info.Key == ConsoleKey.RightArrow && Menu_number_Errival_type < 5)
                                ++Menu_number_Errival_type;
                            if (Arrival_Type_Key_Info.Key == ConsoleKey.LeftArrow && Menu_number_Errival_type > 1)
                                --Menu_number_Errival_type;
                            if (Arrival_Type_Key_Info.Key == ConsoleKey.Enter)
                                break;
                           // Menu_number_Errival_type = 0;
                        }
                        break;

                    case 7:
                        if (!Int32.TryParse(New_Arrival_Array[New_arrival_punkt_menu - 1], out int_to_try))
                        {
                            New_Arrival_Array[New_arrival_punkt_menu - 1] = "";
                            Console.SetCursorPosition(38, 1 + (New_arrival_punkt_menu * 2));
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("Введите целое число!");
                            Console.ForegroundColor = ConsoleColor.White;
                            New_arrival_punkt_menu = --New_arrival_punkt_menu;
                            Console.SetCursorPosition(23, 3 + (New_arrival_punkt_menu * 2));
                            Console.ReadKey();
                        };
                        break;
                    default:
                        break;
                }
                /*устанавливаем курсор на необходимый пункт меню*/
                if(New_arrival_punkt_menu<7)
                   Console.SetCursorPosition(23, 3 + New_arrival_punkt_menu * 2);
            }
            /*спрашиваем, сохранить новый рейс или нет*/
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.Write("Add new arrival Y/N? ");
            Save_New_Arrival_Ind = Console.ReadLine();
            /*заполняем масив пустыми строками если не нужно сохранять*/
            if (Save_New_Arrival_Ind != "Y")
                for (Int16 i = 1; i <= 7; i++)
                {
                    New_Arrival_Array[i - 1] = null;
                }
            return New_Arrival_Array;

        }
    }

    public class Evacuation
    {
        public void Evacuation_Screen()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(10, 10);
            Console.WriteLine("*******  **    **     **     ********  **     **     **     *********  **   ********   **     **");
            Console.SetCursorPosition(10, 11);
            Console.WriteLine("**       **    **    ****    **        **     **    ****        *      **  **      **  ***    **");
            Console.SetCursorPosition(10, 12);
            Console.WriteLine("**       **    **   **  **   **        **     **   **  **       *      **  **      **  ** *   **");
            Console.SetCursorPosition(10, 13);
            Console.WriteLine("*******  **    **  ********  **        **     **  ********      *      **  **      **  **  *  **");
            Console.SetCursorPosition(10, 14);
            Console.WriteLine("**        **  **   ********  **        **     **  ********      *      **  **      **  **   * **");
            Console.SetCursorPosition(10, 15);
            Console.WriteLine("**         ****    **    **  **        **     **  **    **      *      **  **      **  **    ***");
            Console.SetCursorPosition(10, 16);
            Console.WriteLine("*******     **     **    **  ********   *******   **    **      *      **   ********   **     **");
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Airport information panel. Sukhov I. 2016-02-05"; /*Заголовок консольной формы*/
            String[,] Arrivals_Array = new string[100, 7];          /*Создаем масив с данными по прилетам*/
            /////////////////////////////////////////////////////////////////////////////////////////////////////////
            //тестовый масив прилетов
            /*рейс 1*/
            Arrivals_Array[0, 0] = "U571"; Arrivals_Array[0, 1] = "Berlin Fly"; Arrivals_Array[0, 2] = "16:45";
            Arrivals_Array[0, 3] = "Munich"; Arrivals_Array[0, 4] = "D"; Arrivals_Array[0, 5] = "Delayed"; Arrivals_Array[0, 6] = "12";
            /*рейс 2*/
            Arrivals_Array[1, 0] = "A015"; Arrivals_Array[1, 1] = "Turkish Air"; Arrivals_Array[1, 2] = "17:45";
            Arrivals_Array[1, 3] = "Istambul"; Arrivals_Array[1, 4] = "A"; Arrivals_Array[1, 5] = "Flight"; Arrivals_Array[1, 6] = "3";
            /*рейс 3*/
            Arrivals_Array[2, 0] = "M117"; Arrivals_Array[2, 1] = "MAU"; Arrivals_Array[2, 2] = "10:30";
            Arrivals_Array[2, 3] = "Kyiv/Borispil"; Arrivals_Array[2, 4] = "B"; Arrivals_Array[2, 5] = "Arrived"; Arrivals_Array[2, 6] = "9";
            /*рейс 4*/
            Arrivals_Array[3, 0] = "N737"; Arrivals_Array[3, 1] = "NY Air"; Arrivals_Array[3, 2] = "19:20";
            Arrivals_Array[3, 3] = "New York"; Arrivals_Array[3, 4] = "C"; Arrivals_Array[3, 5] = "Arrived"; Arrivals_Array[3, 6] = "6";
            /*рейс 5*/
            Arrivals_Array[4, 0] = "G737"; Arrivals_Array[4, 1] = "Georgia Fly"; Arrivals_Array[4, 2] = "11:20";
            Arrivals_Array[4, 3] = "Tbilisi"; Arrivals_Array[4, 4] = "A"; Arrivals_Array[4, 5] = "Flight"; Arrivals_Array[4, 6] = "4";
            /*рейс 6*/
            Arrivals_Array[5, 0] = "K190"; Arrivals_Array[5, 1] = "Air Astana"; Arrivals_Array[5, 2] = "23:55";
            Arrivals_Array[5, 3] = "Astana"; Arrivals_Array[5, 4] = "D"; Arrivals_Array[5, 5] = "Flight"; Arrivals_Array[5, 6] = "7";
            /////////////////////////////////////////////////////////////////////////////////////////////////////////
            Main_Menu Main_Menu_List = new Main_Menu();             /*Создаем экземпляр обьекта типа "главное меню"*/
            Arrivals Arrivals_table = new Arrivals();               /*создаем экземпляр обьекта типа "таблица прибытий"*/
            Evacuation Evacuation = new Evacuation();
            ConsoleKeyInfo Console_keyInfo;                         /*Создаем переменную содержит "нажатую клавишу"*/
            Return_To_Main_Menu:                                    /*Метка возврта к главному меню*/
            Main_Menu_List.Show_Main_Menu();                        /*Вызываем метод по отображению главного меню*/
            /*закрытый цикл по пунктам главного меню*/
            while (1==1)                                            
            {
                Console_keyInfo = Console.ReadKey();                /*Считываем нажатую клавишу в переменную*/
                /*При нажатии стрелки вверх - переходим на один пункт меню вверх*/
                if(Console_keyInfo.Key == ConsoleKey.UpArrow)
                   Main_Menu_List.Menu_Position_Number = --Main_Menu_List.Menu_Position_Number;
                /*При нажатии стрелки вниз - переходим на один пункт меню вниз*/
                if (Console_keyInfo.Key == ConsoleKey.DownArrow)
                   Main_Menu_List.Menu_Position_Number = ++Main_Menu_List.Menu_Position_Number;
                /*При нажатии клавиши E - возврат к пункту меню EXIT*/
                if (Console_keyInfo.Key == ConsoleKey.E)
                    Main_Menu_List.Menu_Position_Number = 7;
                /*При нажатии Enter - выход из цикла*/
                if (Console_keyInfo.Key == ConsoleKey.Enter)
                    break;
                Main_Menu_List.Show_Main_Menu();                    /*Вызываем метод по отображению главного меню*/
            };

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////
            /*Блок работы с таблицами прилетов Arrivals*/
            
            ////////////////////////////////////////////
            /*При выборе пункта меню "SHOW ARRIVALS" запускаем панель отображения прилетов*/
            /*Если пункт меню==1 тогда выводим таблицу прибытий "Arrivals"*/
            if (Main_Menu_List.Menu_Position_Number==1)
            {
                Arrivals_table.Show_Arrival_Table_Head();           /*прорисовываем заголовок таблицы*/
                Arrivals_table.Show_Arrival_Table_Data(Arrivals_Array, 1, "No Sort"); /*прорисовываем часть таблицы с данными о прилетах*/
                Arrivals_table.Show_Arrival_Table_End();            /*прорисовываем концовку таблицы*/
                while (1==1)                                        /*Закрытый цикл с переходами по столбцам таблицы*/
                {
                    Console_keyInfo = Console.ReadKey();            /*Считываем нажатую клавишу в переменную*/
                    /*при нажатии стрелки влево- переходим к следующему столбцу*/
                    if (Console_keyInfo.Key == ConsoleKey.RightArrow)
                        Arrivals_table.Arrival_Table_Collumn_Num = ++Arrivals_table.Arrival_Table_Collumn_Num;
                    /*при нажатии стрелки вправо- переходим к предыдущему столбцу*/
                    if (Console_keyInfo.Key == ConsoleKey.LeftArrow)
                        Arrivals_table.Arrival_Table_Collumn_Num = --Arrivals_table.Arrival_Table_Collumn_Num;
                    Arrivals_table.Show_Arrival_Table_Head();
                    /*отслеживаем нажатия клавиш ввре/вниз для сортировки выводимых данных*/
                    switch (Console_keyInfo.Key)
                    {
                        case ConsoleKey.UpArrow:
                            Arrivals_table.Show_Arrival_Table_Data(Arrivals_Array, Arrivals_table.Arrival_Table_Collumn_Num,"ASC");
                            break;
                        case ConsoleKey.DownArrow:
                            Arrivals_table.Show_Arrival_Table_Data(Arrivals_Array, Arrivals_table.Arrival_Table_Collumn_Num, "DESC");
                            break;
                        default:
                            Arrivals_table.Show_Arrival_Table_Data(Arrivals_Array, Arrivals_table.Arrival_Table_Collumn_Num, "No sort");
                            break;
                    }
                    Arrivals_table.Show_Arrival_Table_End();
                    /*при нажатии клавиши E- выходим в начало программы, в главное меню*/
                    if (Console_keyInfo.Key == ConsoleKey.E)
                        goto Return_To_Main_Menu;                                        /*метка переходав в начало программы и запуска главного меню*/
                };
            };

            ////////////////////////////////////////////
            /*При выборе пункта меню "Add new flygth to Arrival" зупаскаем панель отображения прилетов*/
            string[] New_ArrivaL = new string[7];
            if (Main_Menu_List.Menu_Position_Number == 3)
            {
                New_ArrivaL = Arrivals_table.Arrivals_Add_New_Arrival();
                /*добавляем новую запись в наш масив прилетов*/
                if (New_ArrivaL[0] != null & New_ArrivaL[0] != "")
                    for (Int32 i = 1; i <= Arrivals_Array.GetLength(0); i++)
                    {
                        if (Arrivals_Array[i - 1, 0] == null)
                        {
                            for (Int32 j = 1; j <= 7; j++)
                            {
                                Arrivals_Array[i - 1, j - 1] = New_ArrivaL[j - 1];
                            }
                            break;
                        }
                    }
                goto Return_To_Main_Menu;
            }

            ///////////////////////////////////////////
            /*запускаем окно эвакуации*/
            if (Main_Menu_List.Menu_Position_Number == 8)
            {
                Evacuation.Evacuation_Screen();                                     /*выхываем меню создания нового рейса прибытия*/
                Console.ReadLine();
            }
           

            }
    }
}
