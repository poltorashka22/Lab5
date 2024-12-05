using Lab5;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        int point = 1;
        Log log1 = null;
        Supportive supportive = new Supportive(log1); 

        Console.WriteLine("Добро пожаловать в программу для работы с таблицами!");

        Console.WriteLine("Вы бы хотели вести запись этого сеанса в уже существующий файл? (да/нет)");

        try
        {

            string flag = Console.ReadLine().ToLower();
            string file_name_user;
            string defaul_file_name = "log.txt";

            while (flag != "да" && flag != "нет" )
            {
                Console.WriteLine("Введены некорректные данные! Попробуйте еще раз");
                flag = Console.ReadLine();
            }

            if (flag == "да")
            {
                Console.WriteLine("Введите имя файла");
                file_name_user = Console.ReadLine();
                Log log = new Log(file_name_user, true);
                log.Write("Начало записи в файл: " + file_name_user);
            }
            if (flag == "нет")
            {
                Console.WriteLine("Для протоколирования работы приложения будет использован файл - " + defaul_file_name);
                Log log = new Log(defaul_file_name, false);
                log.Write("Начало записи в новый файл: " + defaul_file_name);
            }

        }
        catch (Exception ex)
        {

        }

        
        Console.WriteLine("1 - Вывод содержимого базы данных");
        Console.WriteLine("2 - Удаление элемента базы данных");
        Console.WriteLine("3 - Корректировка элемента базы данных");
        Console.WriteLine("4 - Добавление нового элемента в базу данных");
        Console.WriteLine("5 - Поиск рейсов, начатых в марте 2023 года с расстоянием больше 500 км");
        Console.WriteLine("6 - Поиск водителей, которые совершали рейсы с расстоянием более 1000 км");
        Console.WriteLine("7 - Поиск водителей, которые совершали рейсы на автомобилях старше 10 лет с расстоянием более 1000 км");
        Console.WriteLine("8 - Поиск водителей и автомобилей, на которых были совершены рейсы в феврале 2023 года с расстоянием рейса менее 500 км");
        Console.WriteLine("0 - Завершение работы приложения");


        while (point != 0)
        {
            
            Console.WriteLine("Выберете действие");
            
            try
            {
                point = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Ошибка ввода, попробуйте еще раз");
            }

            supportive.ReadingExcel();

            if (point == 1)
            {

                supportive.Printdatabase();
                //log1.Write("Чтение базы данных");
            }

            if (point == 2)
            {
                Console.WriteLine("Введите имя листа из которого нужно удалить данные");

                try
                {

                    string sheetname = Console.ReadLine().ToLower();

                    while (sheetname != "автомобили" && sheetname != "водители" && sheetname != "рейсы")
                    {
                        Console.WriteLine("Введены некорректные данные! Попробуйте еще раз");
                        sheetname = Console.ReadLine();
                    }

                    int row_id;

                    while (true)
                    {
                        Console.WriteLine("Введите Id строки, которую хотите удалить");

                        bool isValid = int.TryParse(Console.ReadLine(), out row_id);

                        if (isValid && row_id > 0)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Введены некорректные данные! Пожалуйста, введите число больше 0.");
                        }
                    }

                    supportive.DeletingElement(sheetname, row_id);

                }
                catch (Exception ex)
                {

                }

            }

            if (point == 3)
            {
                Console.WriteLine("Введите имя листа в котором нужно скорректировать данные");

                try
                {

                    string sheetname = Console.ReadLine().ToLower();

                    while (sheetname != "автомобили" && sheetname != "водители" && sheetname != "рейсы")
                    {
                        Console.WriteLine("Введены некорректные данные! Попробуйте еще раз");
                        sheetname = Console.ReadLine();
                    }

                    int row_id;

                    while (true)
                    {
                        Console.WriteLine("Введите Id строки, в которой нужно скорректировать данные");

                        bool isValid = int.TryParse(Console.ReadLine(), out row_id);

                        if (isValid && row_id > 0)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Введены некорректные данные! Пожалуйста, введите число больше 0.");
                        }


                    }



                    supportive.CorrectElement(sheetname, row_id);
                }
                catch (Exception ex)
                {

                }


            }

            if (point == 4)
            {
                Console.WriteLine("Введите имя листа в который нужно добавить данные");

                try
                {

                    string sheetname = Console.ReadLine().ToLower();

                    while (sheetname != "автомобили" && sheetname != "водители" && sheetname != "рейсы")
                    {
                        Console.WriteLine("Введены некорректные данные! Попробуйте еще раз");
                        sheetname = Console.ReadLine();
                    }

                    supportive.AddingElement(sheetname);
                }
                catch (Exception ex)
                {

                }
            }

            if (point == 5)
            {
                supportive.FirstRequest();
            }

            if (point == 6)
            {
                supportive.SecondRequest();
            }

            if (point == 7)
            {
                supportive.ThirdRequest();
            }

            if (point == 8)
            {
                supportive.FourthRequest();
            }
        }
        log1.Write("Завершение сеанса");
    }
}
