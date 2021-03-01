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
                new Car{BrandId=1,ColorId=1,DailyPrice=12.99,Description="Fiat",Id=1,ModelYear=2006},
                new Car{BrandId=2,ColorId=1,DailyPrice=22.99,Description="Citroen",Id=2,ModelYear=2012},
                new Car{BrandId=3,ColorId=2,DailyPrice=32.99,Description="Ford",Id=3,ModelYear=2014},
                new Car{BrandId=4,ColorId=2,DailyPrice=42.99,Description="Toyota",Id=4,ModelYear=2015},
                new Car{BrandId=5,ColorId=3,DailyPrice=52.99,Description="Audi",Id=5,ModelYear=2019},
                new Car{BrandId=6,ColorId=4,DailyPrice=62.99,Description="Bmw",Id=6,ModelYear=2020},
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
            _cars.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetById(int id)
        {
            return _cars.Where(c => c.Id == id).ToList();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.Id = car.Id;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }
    }
}
