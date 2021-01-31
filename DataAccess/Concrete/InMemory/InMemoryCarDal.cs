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
                new Car {CarId=1, BrandId=1, ColorId=1, DailyPrice=500, ModelYear=2015, Description= "Audi A3"},
                new Car {CarId=2, BrandId=1, ColorId=2, DailyPrice=800, ModelYear=2018, Description= "Audi Q7"},
                new Car {CarId=3, BrandId=2, ColorId=1, DailyPrice=1000, ModelYear=2019, Description= "BMW Z4"},
                new Car {CarId=4, BrandId=2, ColorId=3, DailyPrice=900, ModelYear=2016, Description= "BMW 3.20i"},
                new Car {CarId=5, BrandId=3, ColorId=1, DailyPrice=400, ModelYear=2012, Description= "Jeep CJ5"}
            };

        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c=>c.CarId == car.CarId);
            _cars.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetById(int carId)
        {
            return _cars.Where(c => c.CarId == carId).ToList();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => car.CarId == car.CarId);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.Description = car.Description;
        }
    }
}
