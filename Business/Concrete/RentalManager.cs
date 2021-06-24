using Backbone.Aspects.Autofac.Validation;
using Backbone.Utilities.Results;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        private IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        } // ctrl M M

        public IResult Delete(int id)
        {
            if (DateTime.Now.Hour >= 22 & DateTime.Now.Hour <= 7)
            {
                return new ErrorResult(Messages.MaintenanceTime);
            }

            var deletedRental = _rentalDal.Get(r => r.CarId == id);
            _rentalDal.Delete(deletedRental);
            return new SuccessResult("Rental Deleted");
        }

        [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rental entity)
        {


            var addedRent = _rentalDal.Get(r => r.CarId == entity.CarId);
            if (DateTime.Now.Hour >= 22 & DateTime.Now.Hour <= 7)
            {
                return new ErrorResult(Messages.MaintenanceTime);
            }
            else if (addedRent == null)
            {
                _rentalDal.Add(entity);
                return new SuccessResult("Araba Kiralandı");
            }
            else
            {
                return new ErrorResult("Araba Zaten Kullanımda");
            }

        }

        public IResult Update(Rental entity)
        {
            if (DateTime.Now.Hour >= 22 & DateTime.Now.Hour <= 7)
            {
                return new ErrorResult(Messages.MaintenanceTime);
            }
            _rentalDal.Update(entity);
            return new SuccessResult("Rental Updated");
        }

        public IDataResult<Rental> Get(int id)
        {
            if (DateTime.Now.Hour >= 22 & DateTime.Now.Hour <= 7)
            {
                return new ErrorDataResult<Rental>(Messages.MaintenanceTime);
            }


            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.RentalId == id), "Rental Has Shown");
        }

        public IDataResult<List<Rental>> GetAll()
        {
            if (DateTime.Now.Hour >= 22 & DateTime.Now.Hour <= 7)
            {
                return new ErrorDataResult<List<Rental>>(Messages.MaintenanceTime);
            }

            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), "Rental Listed");
        }

    }




}

