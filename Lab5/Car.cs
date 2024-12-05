using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lab5
{
    public class Car
    {
        private int id;
        private string mark;
        private string model;
        private int year;

        public Car(int id, string mark, string model, int year)
        {
            this.id = id;
            this.mark = mark;
            this.model = model;
            this.year = year;
        }

        public int Id
        {
            get
            {
                return id;    // возвращаем значение свойства
            }
            set
            {
                id = value;   // устанавливаем новое значение свойства
            }
        }

        public string Mark
        {
            get
            {
                return mark;
            }
            set
            {
                mark = value ?? throw new ArgumentNullException(nameof(value)); // ошибка если присваеваем null
            }
        }

        public string Model
        {
            get
            {
                return model;
            }
            set
            {
                model = value ?? throw new ArgumentNullException(nameof(value));
            }
        }

        public int Year
        {
            get
            {
                return year;
            }
            set
            {
                year = value;
            }
        }

        public override string ToString()
        {
            return $"Id: {id} | Марка {mark} | Модель {model} | Год {year}";
        }


    }
}
