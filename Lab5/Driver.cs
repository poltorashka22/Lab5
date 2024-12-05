using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    public class Driver
    {
        private int id;
        private string name;
        private int age;
        private int drivingexp;

        public Driver(int id, string name, int age, int drivingexp)
        {
            this.id = id;
            this.name = name;
            this.age = age;
            this.drivingexp = drivingexp;
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

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value ?? throw new ArgumentNullException(nameof(value));
            }
        }

        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                age = value;
            }
        }

        public int Drivingexp
        {
            get
            {
                return drivingexp;
            }
            set
            {
                drivingexp = value;
            }
        }

        public override string ToString()
        {
            return $"Id: {id} | Имя водителя {name} | Возраст {age} | Стаж вождения {drivingexp}";
        }
    }
}
