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
using System.Linq;
using Backbone.Aspects.Autofac.Caching;
using Backbone.Aspects.Autofac.Transaction;
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

            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p=>p.ColorId == id), Messages.ProductListed);
        }
        [CacheAspect()]
        public IDataResult<List<Car>> GetAllByBrandId(int id)
        {
            if (DateTime.Now.Hour > 22 && DateTime.Now.Hour < 9)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }

            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.BrandId == id), Messages.ProductListed);
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
        [ValidationAspect(typeof(CarValidator))]
        public IResult Update(Car entity)
        {
          

           

            _carDal.Update(entity);

            return new SuccessResult(Messages.ProductUpdated);
        }

        /*----------------------DTO METHODS---------------------------------*/

        [CacheAspect()]
        public IDataResult<List<CarDto>> GetAllCarDto()
        {
            if (DateTime.Now.Hour > 22 && DateTime.Now.Hour < 9)
            {
                return new ErrorDataResult<List<CarDto>>(Messages.MaintenanceTime);
            }

            return new SuccessDataResult<List<CarDto>>(_carDal.GetCarDto(), Messages.ProductListed);
        }

        public IDataResult<CarDto> GetCarDtoById(int id)
        {
            if (DateTime.Now.Hour > 22 && DateTime.Now.Hour < 9)
            {
                return new ErrorDataResult<CarDto>(Messages.MaintenanceTime);
            }

            return new SuccessDataResult<CarDto>(_carDal.GetCarDtoById(c=>c.Id==id), Messages.ProductListed);
        }

        public IDataResult<List<CarDto>> GetAllDtosByColorId(int id)
        {
            if (DateTime.Now.Hour > 22 && DateTime.Now.Hour < 9)
            {
                return new ErrorDataResult<List<CarDto>>(Messages.MaintenanceTime);
            }

            return new SuccessDataResult<List<CarDto>>(_carDal.GetCarDto(p => p.ColorId == id), Messages.ProductListed);
        }

        public IDataResult<List<CarDto>> GetAllDtosByBrandId(int id)
        {
            if (DateTime.Now.Hour > 22 && DateTime.Now.Hour < 2)
            {
                return new ErrorDataResult<List<CarDto>>(Messages.MaintenanceTime);
            }

            return new SuccessDataResult<List<CarDto>>(_carDal.GetCarDto(p => p.BrandId == id), Messages.ProductListed);

        }

        public IDataResult<List<CarDto>> GetAllDtosByBrandIdColorId(int BrandId, int ColorId)
        {
            if (DateTime.Now.Hour > 22 && DateTime.Now.Hour < 2)
            {
                return new ErrorDataResult<List<CarDto>>(Messages.MaintenanceTime);
            }

            var brandColorFilteredDtos = _carDal.GetCarDto(c => c.BrandId == BrandId && c.ColorId == ColorId);
            

            return new SuccessDataResult<List<CarDto>>(brandColorFilteredDtos, Messages.ProductListed);

        }
    


        /* ----------------------BUSINESS RULES-------------------------------*/


        [TransactionAspect]
        public IResult AddTransactionalTest(Car car)
        {
            Add(car);
            if (car.DailyPrice < 1000)
            {
                throw new Exception("");
            }
            Add(car);
            return null;

        }

    }
}
