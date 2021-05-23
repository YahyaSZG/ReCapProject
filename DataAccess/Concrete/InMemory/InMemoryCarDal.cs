using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{Id=1, BrandId=1, ColorId=1, Creator="yahya", CreateTime= DateTime.Now, Description="Ford" }
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
            Console.WriteLine(car.Description + " eklendi.");
        }

        public void Delete(Car car)
        {
            _cars.Remove(_cars.SingleOrDefault(c => c.Id == car.Id));
            Console.WriteLine(car.Description + " silindi.");
        }

        public List<Car> GetAll()
        {
            foreach (var item in _cars)
            {
                Console.WriteLine(item);
            }
            return _cars;
        }

        public Car GetById(int Id)
        {            
            var item = _cars.SingleOrDefault(c => c.Id == Id);
            Console.WriteLine(item.Description);
            return item;
        }

        public void Update(Car car)
        {
            var item = _cars.SingleOrDefault(c => c.Id == car.Id);
            Console.WriteLine(item.Description + " - " + car.Description);
            item.Description = car.Description;
        }
    }
}
