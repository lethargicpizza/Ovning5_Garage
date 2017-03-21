using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq
{
    class Program
    {
        static void Main(string[] args)
        {
            var people = new List<Person>
            {
               new Person() {ID = 1, Name ="Per Nordenbrink", Birthdate=DateTime.Parse("1980-11-18") },
               new Person() {ID = 2, Name ="Cosette El-Boustany", Birthdate=DateTime.Parse("1981-11-24") },
               new Person() {ID = 3, Name ="Tore Thjelvarsson", Birthdate=DateTime.Parse("2007-05-21") },
               new Person() {ID = 4, Name ="Kalle Kula", Birthdate=DateTime.Parse("1979-01-06") }
            };

            var cars = new List<Car>
            {
                new Car() {Brand="Volvo", MaxSpeed=120, OwnerId = 2 },
                new Car() {Brand="Porsche", MaxSpeed=220, OwnerId = 3 },
                new Car() {Brand="Tesla", MaxSpeed=180, OwnerId = 1 },
                new Car() {Brand="Corvette", MaxSpeed=250, OwnerId = 1 }
            };

            var sportsCars = cars.Where(car => car.MaxSpeed > 200);
            var sportsCarsBrands = sportsCars.Select(car => car.Brand);

            //Console.WriteLine("Sports cars: ");
            //foreach (var item in sportsCars)
            //{
            //    Console.WriteLine(item.Brand);
            //}

            //foreach (var item in sportsCarsBrands)
            //{
            //    Console.WriteLine(item);
            //}

            //var ages = people
            //    .Select(person => new {
            //        Name = person.Name,
            //        Age = (int)(DateTime.Today - person.Birthdate).TotalDays / 365
            //    });

            //foreach (var item in ages)
            //{
            //    Console.WriteLine($"{item.Name} is {item.Age} years old");
            //}

            var owners = people
                .GroupJoin(cars, p => p.ID, c => c.OwnerId, (p, ownedCars) => new
                {
                    Owner = p,
                    Cars = ownedCars
                })
                .Where(o => o.Cars.Count() != 0);

            Console.WriteLine("Owners and their cars:");
            foreach (var ownership in owners)
            {
                var owner = ownership.Owner;
                Console.WriteLine($"{owner.Name}");

                foreach (var car in ownership.Cars)
                {
                    Console.WriteLine($"   {car.Brand} \t(max speed: {car.MaxSpeed}) ");
                }
            }
        }
    }

    class Person
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime Birthdate { get; set; }
    }

    class Car
    {
        public string Brand { get; set; }
        public int MaxSpeed { get; set; }
        public int OwnerId { get; set; }
    }
}
