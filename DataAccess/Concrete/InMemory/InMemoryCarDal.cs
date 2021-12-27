using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.InMemory
{
   public class InMemoryCarDal:ICarDal
   {
       private List<Car> _cars;

        public InMemoryCarDal()
       {
           _cars = new List<Car>
           {
               new Car{Id= 1,BrandId = 1,ColorId = 1,DailyPrice = 20000,ModelYear = "2010",Description= "Black Ford Focus"},
               new Car{Id= 2,BrandId = 1,ColorId = 2,DailyPrice = 50000,ModelYear = "2015",Description= "White Ford Mustang"},
               new Car{Id= 3,BrandId = 2,ColorId = 3,DailyPrice = 90000,ModelYear = "2020", Description= "Yellow Chevrolet Corvette"},
               new Car{Id= 4,BrandId = 2,ColorId = 3,DailyPrice = 15000,ModelYear = "2009",Description= "Yellow Chevrolet Camaro"},
               new Car{Id= 5,BrandId = 3,ColorId = 3,DailyPrice = 14000,ModelYear = "2017",Description= "Volkswagen Passat"},
               new Car{Id= 6,BrandId = 3,ColorId = 4,DailyPrice = 35000,ModelYear = "2021",Description= "Volkswagen Golf"},
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
            var carForDelete = _cars.SingleOrDefault(p => p.Id== car.Id);
            _cars.Remove(carForDelete);
        }

        public void Update(Car car)
        {
            var carForUpdate = _cars.SingleOrDefault(p => p.Id== car.Id);
            carForUpdate.BrandId = car.BrandId;
            carForUpdate.ColorId = car.ColorId;
            carForUpdate.DailyPrice = car.DailyPrice;
            carForUpdate.Description= car.Description;
            carForUpdate.ModelYear = car.ModelYear;



        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDescription()
        {
            throw new NotImplementedException();
        }
   }
}
