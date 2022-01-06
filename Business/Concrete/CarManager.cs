using Backbone.Aspects.Autofac.Validation;
using Backbone.Utilities.Results;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using Backbone.Aspects.Autofac.Caching;
using Business.BusinessAspects.Autofac;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        private ICarDal _carDal;


        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Delete(int id)
        {
            if (DateTime.Now.Hour > 22 && DateTime.Now.Hour < 9)
            {
                return new ErrorResult(Messages.MaintenanceTime);
            }
            var deletedcar = _carDal.Get(p => p.Id == id);
            _carDal.Delete(deletedcar);
            return new SuccessResult(Messages.ProductDeleted);
        }


        [CacheAspect()]
        public IDataResult<Car> Get(int id)
        {
            if (DateTime.Now.Hour > 22 && DateTime.Now.Hour < 9)
            {
                return new ErrorDataResult<Car>(Messages.MaintenanceTime);
            }

            return new SuccessDataResult<Car>(_carDal.Get(p => p.Id == id), Messages.ProductShown);
        }
        [CacheAspect()]
        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            if (DateTime.Now.Hour > 22 && DateTime.Now.Hour < 9)
            {
                return new ErrorDataResult<List<CarDetailDto>>(Messages.MaintenanceTime);
            }

            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(), Messages.ProductListed);
        }

        [CacheAspect]
        public IDataResult<List<Car>> GetAll()
        {
            if (DateTime.Now.Hour > 22 && DateTime.Now.Hour < 9)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }

            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.ProductListed);
        }
        [CacheAspect()]
        public IDataResult<List<Car>> GetAllByColorId(int id)
        {
            if (DateTime.Now.Hour > 22 && DateTime.Now.Hour < 9)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }

            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.ColorId == id), Messages.ProductListed);
        }
        
        [CacheAspect()]
        public IDataResult<List<Car>> GetAllByPrice(int min, int max)
        {
            if (DateTime.Now.Hour > 22 && DateTime.Now.Hour < 9)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }

            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.DailyPrice >= min && p.DailyPrice <= max), Messages.ProductListed);
        }
        [CacheRemoveAspect("ICarService.Get")]
        [SecuredOperation("Car.List,admin")]
        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car entity)
        {


            _carDal.Add(entity);
            return new SuccessResult(Messages.ProductAdded);

        }
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Update(Car entity)
        {
            if (DateTime.Now.Hour > 22 && DateTime.Now.Hour < 9)
            {
                return new ErrorResult(Messages.MaintenanceTime);
            }
            _carDal.Update(entity);
            return new SuccessResult(Messages.ProductUpdated);
        }
        /* ----------------------BUSINESS RULES-------------------------------*/


    }
}
