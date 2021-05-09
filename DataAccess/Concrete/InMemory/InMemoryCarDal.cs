using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.InMemory
{
   public class InMemoryCarDal:ICarDal
   {
       private List<Car> _cars;

        public InMemoryCarDal()
       {
           _cars = new List<Car>
           {
               new Car{CarId= 1,BrandId = 1,ColorId = 1,DailyPrice = 20000,ModelYear = "2010",Details= "Black Ford Focus"},
               new Car{CarId= 2,BrandId = 1,ColorId = 2,DailyPrice = 50000,ModelYear = "2015",Details= "White Ford Mustang"},
               new Car{CarId= 3,BrandId = 2,ColorId = 3,DailyPrice = 90000,ModelYear = "2020", Details= "Yellow Chevrolet Corvette"},
               new Car{CarId= 4,BrandId = 2,ColorId = 3,DailyPrice = 15000,ModelYear = "2009",Details= "Yellow Chevrolet Camaro"},
               new Car{CarId= 5,BrandId = 3,ColorId = 3,DailyPrice = 14000,ModelYear = "2017",Details= "Volkswagen Passat"},
               new Car{CarId= 6,BrandId = 3,ColorId = 4,DailyPrice = 35000,ModelYear = "2021",Details= "Volkswagen Golf"},
           };
       }
        public List<Car> GetAllBrandId(int brandId)
        {
            return _cars.Where(p => p.BrandId == brandId).ToList();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

       

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            return _cars.SingleOrDefault();
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            var carForDelete = _cars.SingleOrDefault(p => p.CarId == car.CarId);
            _cars.Remove(carForDelete);
        }

        public void Update(Car car)
        {
            var carForUpdate = _cars.SingleOrDefault(p => p.CarId == car.CarId);
            carForUpdate.BrandId = car.BrandId;
            carForUpdate.ColorId = car.ColorId;
            carForUpdate.DailyPrice = car.DailyPrice;
            carForUpdate.Details = car.Details;
            carForUpdate.ModelYear = car.ModelYear;



        }
    }
}
