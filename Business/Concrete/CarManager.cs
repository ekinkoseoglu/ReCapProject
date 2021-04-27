﻿using System;
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

         public List<Car> GetAll()
         {
            return _carDal.GetAll();
         }
    }
}
