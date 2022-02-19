
using Backbone.Aspects.Autofac.Validation;
using Backbone.Utilities.Results;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using Backbone.Aspects.Autofac.Caching;
using Backbone.Utilities.Business;


namespace Business.Concrete
{
    public class BrandManager : IBrandService

    {
        private IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        [CacheRemoveAspect("IBrandService.Get")]
        public IResult Delete(int id)
        {
            if (DateTime.Now.Hour > 22 && DateTime.Now.Hour < 9)
            {
                return new ErrorResult(Messages.MaintenanceTime);
            }
            var deletedBrand = _brandDal.Get(b => b.Id == id);
            _brandDal.Delete(deletedBrand);
            return new SuccessResult(Messages.ProductDeleted);
        }

        [CacheRemoveAspect("IBrandService.Get")]
        [ValidationAspect(typeof(BrandValidator))]
        public IResult Add(Brand entity)
        {

            var result = BusinessRules.Run(CheckBrand(entity.Name));

            if (result!=null)
            {
                return result;
            }

            _brandDal.Add(entity);
            return new SuccessResult(Messages.ProductAdded);
        }

        [CacheRemoveAspect("IBrandService.Get")]

        public IResult Update(Brand entity)
        {
            if (DateTime.Now.Hour > 22 && DateTime.Now.Hour < 9)
            {
                return new ErrorResult(Messages.MaintenanceTime);
            }
            _brandDal.Update(entity);
            return new SuccessResult(Messages.ProductUpdated);
        }

        public IDataResult<Brand> Get(int id)
        {
            if (DateTime.Now.Hour > 22 && DateTime.Now.Hour < 9)
            {
                return new ErrorDataResult<Brand>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<Brand>(_brandDal.Get(b => b.Id == id), Messages.ProductShown);
        }


        [CacheAspect()]
        public IDataResult<List<Brand>> GetAll()
        {
            if (DateTime.Now.Hour > 22 && DateTime.Now.Hour < 9)
            {
                return new ErrorDataResult<List<Brand>>(Messages.MaintenanceTime);
            }

            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(), Messages.ProductListed);
        }




        /* ----------------------BUSINESS RULES-------------------------------*/


        private IResult CheckBrand(string brandName)
        {
            var result = _brandDal.GetAll(b => b.Name == brandName).Any();
            if (result)
            {
                return new ErrorResult("Mevcut Marka Mevcuttur.");
            }

            return new SuccessResult();
        }
    }
}
