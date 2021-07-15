using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
                new Car{Id=1, BrandId=1, ColorId=1, Creator="yahya", CreateTime= DateTime.Now, Description="Focus" },
                new Car{Id=2, BrandId=1, ColorId=1, Creator="yahya", CreateTime= DateTime.Now, Description="Fiesta" },
                new Car{Id=3, BrandId=2, ColorId=3, Creator="yahya", CreateTime= DateTime.Now, Description="Golf" },
                new Car{Id=4, BrandId=3, ColorId=2, Creator="yahya", CreateTime= DateTime.Now, Description="Egea" }
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

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Car GetById(int Id)
        {
            var item = _cars.SingleOrDefault(c => c.Id == Id);
            Console.WriteLine(item.Description);
            return item;
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            var item = _cars.SingleOrDefault(c => c.Id == car.Id);
            Console.WriteLine(item.Description + " - " + car.Description);
            item.Description = car.Description;
        }
    }
}
