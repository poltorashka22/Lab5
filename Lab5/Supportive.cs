using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aspose.Cells;

namespace Lab5
{
    public class Supportive
    {
        private List<Car> cars;
        private List<Driver> drivers;
        private List<Flights> flights;
        //private Log loger;

        public Supportive(Log log)
        {
            cars = new List<Car>();
            drivers = new List<Driver>();
            flights = new List<Flights>();
            //loger = log;
        }

        public void ReadingExcel()
        {
            //loger.Write("Чтение базы данных");
            Workbook wb = new Workbook("LR5-var4.xls");

            Worksheet sheet_car = wb.Worksheets[0];

            cars = sheet_car.Cells.Rows.Cast<Row>()    // Преобразуем строки в LINQ-совместимую коллекцию
            .Skip(1)                          // Пропускаем первую строку (заголовки)
            .Select(row => new Car(
                int.Parse(row.GetCellOrNull(0)?.Value.ToString() ?? "0"),   // ID
                row.GetCellOrNull(1)?.Value.ToString() ?? string.Empty,    // Марка
                row.GetCellOrNull(2)?.Value.ToString() ?? string.Empty,    // Модель
                int.Parse(row.GetCellOrNull(3)?.Value.ToString() ?? "0")   // Год
            ))
            .ToList(); // Преобразуем результат в список


            Worksheet sheet_driver = wb.Worksheets[1];

            drivers = sheet_driver.Cells.Rows.Cast<Row>()    
            .Skip(1)                          
            .Select(row => new Driver(
                int.Parse(row.GetCellOrNull(0)?.Value.ToString() ?? "0"),   // ID
                row.GetCellOrNull(1)?.Value.ToString() ?? string.Empty,    // Имя
                int.Parse(row.GetCellOrNull(2)?.Value.ToString() ?? "0"),  // Возраст
                int.Parse(row.GetCellOrNull(3)?.Value.ToString() ?? "0")   // Стаж
            ))
            .ToList(); // Преобразуем результат в список

            Worksheet sheet_flights = wb.Worksheets[2];

            flights = sheet_flights.Cells.Rows.Cast<Row>()
            .Skip(1)
            .Select(row => new Flights(
                int.Parse(row.GetCellOrNull(0)?.Value.ToString() ?? "0"),   // ID
                int.Parse(row.GetCellOrNull(1)?.Value.ToString() ?? "0"),   // ID машины                                                        
                int.Parse(row.GetCellOrNull(2)?.Value.ToString() ?? "0"),   // ID водителя
                DateTime.Parse(row.GetCellOrNull(3)?.Value.ToString() ?? DateTime.MinValue.ToString()), // Дата начала рейса
                DateTime.Parse(row.GetCellOrNull(4)?.Value.ToString() ?? DateTime.MinValue.ToString()), // Дата конца рейса
                double.Parse(row.GetCellOrNull(5)?.Value.ToString() ?? "0.0"), // Расстояние
                decimal.Parse(row.GetCellOrNull(6)?.Value.ToString() ?? "0.0") //Стоимость
            ))
            .ToList();
        }

        public void  Printdatabase()
        {
            Console.WriteLine("Вывод таблицы автомобили");
            Console.WriteLine();
            //loger.Write("Вывод таблицы автомобили");

            // Вывод списка автомобилей на консоль
            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }

            Console.WriteLine();
            Console.WriteLine("Вывод таблицы водителей");
            Console.WriteLine();
            //loger.Write("Вывод таблицы водителей");

            // Вывод списка водителей на консоль
            foreach (var driver in drivers)
            {
                Console.WriteLine(driver);
            }

            Console.WriteLine();
            Console.WriteLine("Вывод таблицы рейсов");
            Console.WriteLine();
            //loger.Write("Вывод таблицы рейсов");

            // Вывод списка рейсов на консоль
            foreach (var flight in flights)
            {
                Console.WriteLine(flight);
            }
        }

        public void DeletingElement(string sheetname, int row_id)
        {
            switch (sheetname) 
            {
                case "автомобили":
                    //loger.Write("Удаление элемента из таблицы автомобили");
                    var carToDelete = cars.FirstOrDefault(c => c.Id == row_id);
                    if (carToDelete != null)
                    {
                        cars.Remove(carToDelete); 
                        Console.WriteLine($"Автомобиль с ID {row_id} удален.");
                        //loger.Write($"Автомобиль с ID {row_id} удален.");
                    }
                    else
                    {
                        Console.WriteLine($"Автомобиль с ID {row_id} не найден.");
                        //loger.Write($"Автомобиль с ID {row_id} не найден.");
                    }
                    break;

                case "водители":
                    //loger.Write("Удаление элемента из таблицы водители");
                    var driverToDelete = drivers.FirstOrDefault(d => d.Id == row_id);
                    if (driverToDelete != null)
                    {
                        drivers.Remove(driverToDelete); 
                        Console.WriteLine($"Водитель с ID {row_id} удален.");
                        //loger.Write($"Водитель с ID {row_id} удален.");
                    }
                    else
                    {
                        Console.WriteLine($"Водитель с ID {row_id} не найден.");
                        //loger.Write($"Водитель с ID {row_id} не найден.");
                    }
                    break;

                case "рейсы":
                    //loger.Write("Удаление элемента из таблицы рейсы");
                    var flightToDelete = flights.FirstOrDefault(f => f.Id == row_id);
                    if (flightToDelete != null)
                    {
                        flights.Remove(flightToDelete); 
                        Console.WriteLine($"Рейс с ID {row_id} удален.");
                        //loger.Write($"Рейс с ID {row_id} удален.");
                    }
                    else
                    {
                        Console.WriteLine($"Рейс с ID {row_id} не найден.");
                        //loger.Write($"Рейс с ID {row_id} не найден.");
                    }
                    break;
            }
            UpdateExcelFile();
        }

        public void UpdateExcelFile()
        {
            Workbook wb = new Workbook("LR5-var4.xls");

           

            Worksheet sheet_car = wb.Worksheets[0];
            for (int i = 1; i < cars.Count + 1; i++) 
            {
                var car = cars[i - 1]; 
                sheet_car.Cells[i, 0].PutValue(car.Id);
                sheet_car.Cells[i, 1].PutValue(car.Mark);
                sheet_car.Cells[i, 2].PutValue(car.Model);
                sheet_car.Cells[i, 3].PutValue(car.Year);
            }

            
            Worksheet sheet_driver = wb.Worksheets[1];
            for (int i = 1; i < drivers.Count + 1; i++) 
            {
                var driver = drivers[i - 1]; 
                sheet_driver.Cells[i, 0].PutValue(driver.Id);
                sheet_driver.Cells[i, 1].PutValue(driver.Name);
                sheet_driver.Cells[i, 2].PutValue(driver.Age);
                sheet_driver.Cells[i, 3].PutValue(driver.Drivingexp);
            }

            
            Worksheet sheet_flights = wb.Worksheets[2];
            for (int i = 1; i < flights.Count + 1; i++) 
            {
                var flight = flights[i - 1]; 
                sheet_flights.Cells[i, 0].PutValue(flight.Id);
                sheet_flights.Cells[i, 1].PutValue(flight.Id_car);
                sheet_flights.Cells[i, 2].PutValue(flight.Id_driver);
                sheet_flights.Cells[i, 3].PutValue(flight.Flight_start);
                sheet_flights.Cells[i, 4].PutValue(flight.Flight_end);
                sheet_flights.Cells[i, 5].PutValue(flight.Distance);
                sheet_flights.Cells[i, 6].PutValue(flight.Price);
            }

            wb.Save("LR5-var4.xls");
            Console.WriteLine("Excel файл обновлен.");
            //loger.Write("Excel файл обновлен.");
        }

        public void CorrectElement(string sheetname, int row_id)
        {
            switch (sheetname)
            {
                case "автомобили":
                    //loger.Write("Изменение элемента таблицы автомобили.");
                    var carToUpdate = cars.FirstOrDefault(c => c.Id == row_id);

                    if (carToUpdate != null)
                    {
                        Console.WriteLine($"Вы выбрали автомобиль: {carToUpdate}");

                        // Обновляем марку
                        string mark;
                        while (true)
                        {
                            Console.WriteLine("Введите новую марку автомобиля:");
                            mark = Console.ReadLine();
                            if (!string.IsNullOrWhiteSpace(mark))
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Марка не может быть пустой или числом. Пожалуйста, введите корректное значение.");
                            }
                        }
                        carToUpdate.Mark = mark;

                        // Обновляем модель
                        string model;
                        while (true)
                        {
                            Console.WriteLine("Введите новую модель автомобиля:");
                            model = Console.ReadLine();
                            if (!string.IsNullOrWhiteSpace(model))
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Модель не может быть пустой. Пожалуйста, введите корректное значение.");
                            }
                        }
                        carToUpdate.Model = model;

                        // Обновляем год
                        int year;
                        while (true)
                        {
                            Console.WriteLine("Введите новый год автомобиля:");
                            if (int.TryParse(Console.ReadLine(), out year) && year > 0)
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Неверный ввод! Пожалуйста, введите положительное число для года.");
                            }
                        }
                        carToUpdate.Year = year;

                        Console.WriteLine($"Автомобиль с ID {carToUpdate.Id} обновлен!");
                        //loger.Write($"Автомобиль с ID {carToUpdate.Id} обновлен!");
                    }
                    else
                    {
                        Console.WriteLine($"Автомобиль с ID {row_id} не найден.");
                        //loger.Write($"Автомобиль с ID {row_id} не найден.");
                    }
                    break;

                case "водители":
                    //loger.Write("Изменение элемента таблицы водители.");
                    var driverToUpdate = drivers.FirstOrDefault(d => d.Id == row_id);

                    if (driverToUpdate != null)
                    {
                        Console.WriteLine($"Вы выбрали водителя: {driverToUpdate}");

                        // Обновляем имя водителя
                        string name;
                        while (true)
                        {
                            Console.WriteLine("Введите новое имя водителя:");
                            name = Console.ReadLine();
                            if (!string.IsNullOrWhiteSpace(name))
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Имя не может быть пустым. Пожалуйста, введите корректное имя.");
                            }
                        }
                        driverToUpdate.Name = name;

                        // Обновляем возраст водителя
                        int age;
                        while (true)
                        {
                            Console.WriteLine("Введите новый возраст водителя:");
                            if (int.TryParse(Console.ReadLine(), out age) && age > 0)
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Неверный ввод! Пожалуйста, введите положительное число для возраста.");
                            }
                        }
                        driverToUpdate.Age = age;

                        // Обновляем стаж водителя
                        int drivingExp;
                        while (true)
                        {
                            Console.WriteLine("Введите новый стаж водителя:");
                            if (int.TryParse(Console.ReadLine(), out drivingExp) && drivingExp >= 0)
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Неверный ввод! Пожалуйста, введите положительное число для стажа.");
                            }
                        }
                        driverToUpdate.Drivingexp = drivingExp;

                        Console.WriteLine($"Водитель с ID {driverToUpdate.Id} обновлен!");
                        //loger.Write($"Водитель с ID {driverToUpdate.Id} обновлен!");
                    }
                    else
                    {
                        Console.WriteLine($"Водитель с ID {row_id} не найден.");
                        //loger.Write($"Водитель с ID {row_id} не найден.");
                    }
                    break;

                case "рейсы":
                    //loger.Write("Изменение элемента таблицы рейсы.");
                    var flightToUpdate = flights.FirstOrDefault(f => f.Id == row_id);

                    if (flightToUpdate != null)
                    {
                        Console.WriteLine($"Вы выбрали рейс: {flightToUpdate}");

                        // Обновляем ID автомобиля
                        int carId;
                        while (true)
                        {
                            Console.WriteLine("Введите новый ID автомобиля:");
                            if (int.TryParse(Console.ReadLine(), out carId) && carId > 0)
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Неверный ввод! Пожалуйста, введите положительное число для ID автомобиля.");
                            }
                        }
                        flightToUpdate.Id_car = carId;

                        // Обновляем ID водителя
                        int driverId;
                        while (true)
                        {
                            Console.WriteLine("Введите новый ID водителя:");
                            if (int.TryParse(Console.ReadLine(), out driverId) && driverId > 0)
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Неверный ввод! Пожалуйста, введите положительное число для ID водителя.");
                            }
                        }
                        flightToUpdate.Id_driver = driverId;

                        // Обновляем дату начала рейса
                        DateTime flightStart;
                        while (true)
                        {
                            Console.WriteLine("Введите новую дату начала рейса (yyyy-MM-dd):");
                            if (DateTime.TryParse(Console.ReadLine(), out flightStart))
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Неверный формат даты! Пожалуйста, введите дату в формате yyyy-MM-dd.");
                            }
                        }
                        flightToUpdate.Flight_start = flightStart;

                        // Обновляем дату конца рейса
                        DateTime flightEnd;
                        while (true)
                        {
                            Console.WriteLine("Введите новую дату конца рейса (yyyy-MM-dd):");
                            if (DateTime.TryParse(Console.ReadLine(), out flightEnd))
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Неверный формат даты! Пожалуйста, введите дату в формате yyyy-MM-dd.");
                            }
                        }
                        flightToUpdate.Flight_end = flightEnd;

                        // Обновляем расстояние
                        double distance;
                        while (true)
                        {
                            Console.WriteLine("Введите новое расстояние (км):");
                            if (double.TryParse(Console.ReadLine(), out distance) && distance >= 0)
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Неверный ввод! Пожалуйста, введите корректное расстояние.");
                            }
                        }
                        flightToUpdate.Distance = distance;

                        // Обновляем стоимость рейса
                        decimal price;
                        while (true)
                        {
                            Console.WriteLine("Введите новую стоимость рейса:");
                            if (decimal.TryParse(Console.ReadLine(), out price) && price >= 0)
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Неверный ввод! Пожалуйста, введите корректную стоимость.");
                            }
                        }
                        flightToUpdate.Price = price;

                        Console.WriteLine($"Рейс с ID {flightToUpdate.Id} обновлен!");
                        //loger.Write($"Рейс с ID {flightToUpdate.Id} обновлен!");
                    }
                    else
                    {
                        Console.WriteLine($"Рейс с ID {row_id} не найден.");
                        //loger.Write($"Рейс с ID {row_id} не найден.");
                    }
                    break;
            }
            UpdateExcelFile();
        }

        public void AddingElement(string sheetname)
        {
            switch (sheetname)
            {
                case "автомобили":
                    //loger.Write("Добавление элемента в таблицу автомобили");
                    int carId = cars.LastOrDefault()?.Id + 1 ?? 1; ;

                    string mark;
                    while (true)
                    {
                        Console.WriteLine("Введите марку автомобиля:");
                        mark = Console.ReadLine();
                        if (!string.IsNullOrWhiteSpace(mark))
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Марка не может быть пустой или числом. Пожалуйста, введите корректное значение.");
                        }
                    }

                    string model;
                    while (true)
                    {
                        Console.WriteLine("Введите модель автомобиля:");
                        model = Console.ReadLine();
                        if (!string.IsNullOrWhiteSpace(model))
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Модель не может быть пустой. Пожалуйста, введите корректное значение.");
                        }
                    }

                    int year;
                    while (true)
                    {
                        Console.WriteLine("Введите выпуска год автомобиля:");
                        if (int.TryParse(Console.ReadLine(), out year) && year > 0)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Неверный ввод! Пожалуйста, введите положительное число для года.");
                        }
                    }

                    Car newCar = new Car(carId, mark, model, year);
                    cars.Add(newCar);
                    Console.WriteLine($"Автомобиль с ID {carId} добавлен!");
                    //loger.Write($"Автомобиль с ID {carId} добавлен!");
                    break;

                case "водители":

                    //loger.Write("Добавление элемента в таблицу водители");
                    int driverId = drivers.LastOrDefault()?.Id + 1 ?? 1;

                    string driverName;
                    while (true)
                    {
                        Console.WriteLine("Введите имя водителя:");
                        driverName = Console.ReadLine();
                        if (!string.IsNullOrWhiteSpace(driverName))
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Пожалуйста, введите имя корректно.");
                        }
                    }

                    int age;
                    while (true)
                    {
                        Console.WriteLine("Введите возраст водителя:");
                        if (int.TryParse(Console.ReadLine(), out age) && age > 0)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Неверный ввод! Пожалуйста, введите положительное число для возраста.");
                        }
                    }

                    int drivingExp;
                    while (true)
                    {
                        Console.WriteLine("Введите стаж водителя:");
                        if (int.TryParse(Console.ReadLine(), out drivingExp) && drivingExp >= 0)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Неверный ввод! Пожалуйста, введите положительное число для стажа.");
                        }
                    }

                    Driver newDriver = new Driver(driverId, driverName, age, drivingExp);
                    drivers.Add(newDriver);

                    Console.WriteLine($"Водитель с ID {driverId} добавлен!");
                    //loger.Write($"Водитель с ID {driverId} добавлен!");
                    break;

                case "рейсы":

                    //loger.Write("Добавление элемента в таблицу рейсы");
                    int flightId = flights.LastOrDefault()?.Id + 1 ?? 1;

                    int carIdForFlight;
                    while (true)
                    {
                        Console.WriteLine("Введите ID автомобиля для рейса:");
                        if (int.TryParse(Console.ReadLine(), out carIdForFlight) && carIdForFlight > 0)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Неверный ввод! Пожалуйста, введите корректный ID автомобиля.");
                        }
                    }

                    int driverIdForFlight;
                    while (true)
                    {
                        Console.WriteLine("Введите ID водителя для рейса:");
                        if (int.TryParse(Console.ReadLine(), out driverIdForFlight) && driverIdForFlight > 0)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Неверный ввод! Пожалуйста, введите корректный ID водителя.");
                        }
                    }

                    DateTime flightStart;
                    while (true)
                    {
                        Console.WriteLine("Введите дату начала рейса (yyyy-MM-dd):");
                        if (DateTime.TryParse(Console.ReadLine(), out flightStart))
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Неверный формат даты! Пожалуйста, введите дату в формате yyyy-MM-dd.");
                        }
                    }

                    DateTime flightEnd;
                    while (true)
                    {
                        Console.WriteLine("Введите дату конца рейса (yyyy-MM-dd):");
                        if (DateTime.TryParse(Console.ReadLine(), out flightEnd))
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Неверный формат даты! Пожалуйста, введите дату в формате yyyy-MM-dd.");
                        }
                    }

                    double distance;
                    while (true)
                    {
                        Console.WriteLine("Введите расстояние рейса (км):");
                        if (double.TryParse(Console.ReadLine(), out distance) && distance >= 0)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Неверный ввод! Пожалуйста, введите корректное расстояние.");
                        }
                    }

                    decimal price;
                    while (true)
                    {
                        Console.WriteLine("Введите стоимость рейса:");
                        if (decimal.TryParse(Console.ReadLine(), out price) && price >= 0)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Неверный ввод! Пожалуйста, введите корректную стоимость.");
                        }
                    }


                    Flights newFlight = new Flights(flightId, carIdForFlight, driverIdForFlight, flightStart, flightEnd, distance, price);
                    flights.Add(newFlight);

                    Console.WriteLine($"Рейс с ID {flightId} добавлен!");
                    //loger.Write($"Рейс с ID {flightId} добавлен!");
                    break;
            }
            UpdateExcelFile();
        }

        public void FirstRequest()
        {
            //loger.Write("Поиск рейсов, начатых в марте 2023 года с расстоянием больше 500 км");
            var marchFlights = flights
            .Where(f => f.Flight_start.Year == 2023 &&  f.Flight_start.Month == 3 &&  f.Distance > 500)             
            .OrderBy(f => f.Flight_start)     
            .Select(f => new
            {
                f.Id,
                f.Id_car,
                f.Id_driver,
                f.Flight_start,
                f.Flight_end,
                f.Distance,
                f.Price
            });

            Console.WriteLine("Рейсы, начатые в марте 2023 года с расстоянием больше 500 км:");

            foreach (var flight in marchFlights)
            {
                Console.WriteLine($"ID рейса: {flight.Id}, ID машины: {flight.Id_car}, ID водителя: {flight.Id_driver}, Дата начала: {flight.Flight_start}, Дата окончания: {flight.Flight_end}, Расстояние: {flight.Distance} км, Стоимость: {flight.Price} руб.");
            }
        }

        public void SecondRequest()
        {
            //loger.Write("Поиск водителей, которые совершали рейсы с расстоянием более 1000 км");
            var uniqueDriversWithLongFlights = flights
                .Where(flight => flight.Distance > 1000)
                .Join(
                    drivers,                          
                    flight => flight.Id_driver,       
                    driver => driver.Id,              
                    (flight, driver) => new           
                    {
                        DriverId = driver.Id,
                        DriverName = driver.Name,
                        DriverExperience = driver.Drivingexp
                    }
                )
                .Distinct() 
                .OrderBy(d => d.DriverName); 

            Console.WriteLine("Водители, которые совершали рейсы с расстоянием более 1000 км:");

            foreach (var driver in uniqueDriversWithLongFlights)
            {
                Console.WriteLine($"ID водителя: {driver.DriverId}, Имя: {driver.DriverName}, Стаж: {driver.DriverExperience} лет");
            }
        }

        public void ThirdRequest()
        {
            //loger.Write("Поиск водителей, которые совершали рейсы на автомобилях старше 10 лет с расстоянием более 1000 км");
            var driversWithOldCarsAndLongFlights = flights
        .Where(flight => flight.Distance > 1000)  
        .Join(
            drivers,                               
            flight => flight.Id_driver,              
            driver => driver.Id,                   
            (flight, driver) => new { flight, driver }  
        )
        .Join(
            cars,                                  
            x => x.flight.Id_car,                   
            car => car.Id,
            (x, car) => new { x.flight, x.driver, car }
        )
        .Where(x => (DateTime.Now.Year - x.car.Year) > 10)  
        .Select(x => new                          
        {
            DriverName = x.driver.Name,
            CarMark = x.car.Mark,
            CarModel = x.car.Model,
            FlightDistance = x.flight.Distance,
            CarYear = x.car.Year
        })
        .OrderBy(x => x.DriverName);  

            
            Console.WriteLine("Водители, которые совершали рейсы на автомобилях старше 10 лет с расстоянием более 1000 км:");

            foreach (var item in driversWithOldCarsAndLongFlights)
            {
                Console.WriteLine($"Имя водителя: {item.DriverName}, Марка авто: {item.CarMark}, Модель: {item.CarModel}, Год выпуска: {item.CarYear}, Расстояние: {item.FlightDistance} км");
            }
        }

        public void FourthRequest()
        {
            //loger.Write("Поиск водителей и автомобилей, на которых были совершены рейсы в феврале 2023 года с расстоянием рейса менее 500 км");
            var carsUsedInShortFlightsInFebruary = flights
            .Where(flight => flight.Distance < 500) 
            .Where(flight => flight.Flight_start.Month == 2 && flight.Flight_start.Year == 2023)  
            .Join(
                cars,                                
                flight => flight.Id_car,              
                car => car.Id,                        
                (flight, car) => new { flight, car }  
            )
            .Join(
                drivers,                              
                x => x.flight.Id_driver,              
                driver => driver.Id,                  
                (x, driver) => new { x.flight, x.car, driver }  
            )
            .Select(x => new                           
            {
                DriverName = x.driver.Name,          
                CarMark = x.car.Mark,               
                CarModel = x.car.Model,             
                FlightDate = x.flight.Flight_start,  
                FlightDistance = x.flight.Distance  
            })
            .OrderBy(x => x.FlightDate);  

            Console.WriteLine("Водители и автомобили, на которых были совершены рейсы в феврале 2023 года с расстоянием рейса менее 500 км:");

            foreach (var item in carsUsedInShortFlightsInFebruary)
            {
                Console.WriteLine($"Водитель: {item.DriverName}, Марка авто: {item.CarMark}, Модель: {item.CarModel}, Дата рейса: {item.FlightDate.ToShortDateString()}, Расстояние: {item.FlightDistance} км");
            }
        }

    }
}
