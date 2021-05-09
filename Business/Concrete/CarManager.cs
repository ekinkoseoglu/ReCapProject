using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
   public class CarManager:ICarService
    {
        private ICarDal _carDal;

         public CarManager(ICarDal carDal)
         {
             _carDal = carDal;
         }

         public Car Get(int id)
         {
             return _carDal.Get(p => p.CarId == id);
         }

         public List<Car> GetAll()
         {
            return _carDal.GetAll();
         }

         public List<Car> GetAllByColorId(int id)
         {
             return _carDal.GetAll(p => p.ColorId==id);
         }

         public List<Car> GetAllByPrice(int min, int max)
         {
             return _carDal.GetAll(p=>p.DailyPrice >=min && p.DailyPrice <= max);
         }
    }
}
