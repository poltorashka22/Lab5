using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lab5
{
    public class Flights
    {
        private int id;
        private int id_car;
        private int id_driver;
        private DateTime flight_start;
        private DateTime flight_end;
        private double distance;
        private decimal price;

        public Flights(int id, int id_car, int id_driver, DateTime flight_start, DateTime flight_end, double distance, decimal price)
        {
            this.id = id;
            this.id_car = id_car;
            this.id_driver = id_driver;
            this.flight_start = flight_start;
            this.flight_end = flight_end;
            this.distance = distance;
            this.price = price;
        }

        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }

        public int Id_car
        {
            get
            {
                return id_car;
            }
            set
            {
                id_car = value;
            }
        }

        public int Id_driver
        {
            get
            {
                return id_driver;
            }
            set
            {
                id_driver = value;
            }
        }

        public DateTime Flight_start
        {
            get
            {
                return flight_start;
            }
            set
            {
                flight_start = value;
            }
        }

        public DateTime Flight_end
        {
            get
            {
                return flight_end;
            }
            set
            {
                flight_end = value;
            }
        }

        public double Distance
        {
            get
            {
                return distance;
            }
            set
            {
                distance = value;
            }
        }

        public decimal Price
        {
            get
            {
                return price;
            }
            set
            {
                price = value;
            }
        }

        public override string ToString()
        {
            return $"Id: {id} | Id машины {id_car} | Id водителя {id_driver} | Дата начала рейса {flight_start} | Дата конца рейса {flight_end} | Расстояние {distance} | Стоимость {price}";
        }
    }
}
