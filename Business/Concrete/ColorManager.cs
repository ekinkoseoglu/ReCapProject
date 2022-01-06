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
    public class ColorManager : IColorService
    {
        private IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {

            _colorDal = colorDal;
        }


        [CacheRemoveAspect("IColorService.Get")]
        public IResult Delete(int id)
        {
            if (DateTime.Now.Hour > 22 && DateTime.Now.Hour < 9)
            {
                return new ErrorResult(Messages.MaintenanceTime);
            }
            var deletedColor = _colorDal.Get(c => c.Id == id);
            _colorDal.Delete(deletedColor);
            return new SuccessResult(Messages.ProductDeleted);
        }


        [CacheRemoveAspect("IColorService.Get")]
        [ValidationAspect(typeof(ColorValidator))]
        public IResult Add(Color entity)
        {
           IResult result = BusinessRules.Run(ColorExist(entity.Name));
            if (result!=null)
            {
                return result;
            }


            _colorDal.Add(entity);
            return new SuccessResult(Messages.ProductAdded);
        }

        [CacheRemoveAspect("IColorService.Get")]

        public IResult Update(Color entity)
        {
            if (DateTime.Now.Hour > 22 && DateTime.Now.Hour < 9)
            {
                return new ErrorResult(Messages.MaintenanceTime);
            }
            _colorDal.Update(entity);
            return new SuccessResult(Messages.ProductUpdated);
        }

        public IDataResult<Color> Get(int id)
        {
            if (DateTime.Now.Hour > 22 && DateTime.Now.Hour < 9)
            {
                return new ErrorDataResult<Color>(Messages.ProductShown);
            }
            return new SuccessDataResult<Color>(_colorDal.Get(c => c.Id == id));
        }
        

        [CacheAspect()]
        public IDataResult<List<Color>> GetAll()
        {
            if (DateTime.Now.Hour > 22 && DateTime.Now.Hour < 9)
            {
                return new ErrorDataResult<List<Color>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll(), Messages.ProductListed);
        }



        /* ----------------------BUSINESS RULES-------------------------------*/


        private IResult ColorExist(string colorName)
        {
            var color = _colorDal.GetAll(c=>c.Name==colorName).Any();
            if (color)
            {
                return new ErrorResult("Mevcut Renk Zaten Mevcut !");
            }

            return new SuccessResult();
        }
    }
}
