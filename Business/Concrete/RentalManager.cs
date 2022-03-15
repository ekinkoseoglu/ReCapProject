using Backbone.Aspects.Autofac.Validation;
using Backbone.Utilities.Results;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using Backbone.Aspects.Autofac.Caching;
using Backbone.Aspects.Autofac.Transaction;
using Backbone.Utilities.Business;
using Castle.DynamicProxy.Generators;
using Entities.DTOs;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        private IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        } // ctrl M M


        [CacheRemoveAspect("IRentalService.Get")]
        public IResult Delete(int id)
        {
            if (DateTime.Now.Hour >= 22 & DateTime.Now.Hour <= 7)
            {
                return new ErrorResult(Messages.MaintenanceTime);
            }

            var deletedRental = _rentalDal.Get(r => r.Id == id);
            _rentalDal.Delete(deletedRental);
            return new SuccessResult("Rental Deleted");
        }


        [CacheRemoveAspect("IRentalService.Get")]
        [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rental entity)
        {




            var rules = BusinessRules.Run(ControlRentDates(entity),ControlCarForRenT(entity));

            if (rules!=null)
            {
                return new ErrorResult(rules.Message);
            }
            _rentalDal.Add(entity);
            return new SuccessResult("Araba Kiralandı");

        }

        [CacheRemoveAspect("IRentalService.Get")]
        public IResult Update(Rental entity)
        {
            if (DateTime.Now.Hour >= 22 & DateTime.Now.Hour <= 7)
            {
                return new ErrorResult(Messages.MaintenanceTime);
            }

            _rentalDal.Update(entity);
            return new SuccessResult("Rental Updated");
        }



        [CacheAspect()]
        public IDataResult<Rental> Get(int id)
        {
            if (DateTime.Now.Hour >= 22 & DateTime.Now.Hour <= 7)
            {
                return new ErrorDataResult<Rental>(Messages.MaintenanceTime);
            }


            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.Id == id), "Rental Has Shown");
        }



        [CacheAspect()]
        public IDataResult<List<Rental>> GetAll()
        {


            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), "Rental Listed");
        }

        public IDataResult<List<RentalDto>> GetRentalDetails()
        {
            if (DateTime.Now.Hour >= 22 & DateTime.Now.Hour <= 1)
            {
                return new ErrorDataResult<List<RentalDto>>(Messages.MaintenanceTime);
            }

            return new SuccessDataResult<List<RentalDto>>(_rentalDal.GetRentalDetails(), "Rental Details Has Listed");
        }

        // ------------------------------BUSINESS RULES --------------------------

        [TransactionAspect]
        public IResult ControlRentDates(Rental rental)
        {
            var rentForControl = _rentalDal.Get(r => r.Id == rental.Id);
            int result = DateTime.Compare(rental.RentDate, rental.ReturnDate);
            if (result > 0)
            {
                throw new Exception("Kiralama Süresi İade etme süresinden sonra olamaz");
            }
            else
            {
                return new SuccessResult();
            }
        }

        [TransactionAspect]
        public IResult ControlCarForRenT(Rental rental)
        {

            var addedRent = _rentalDal.Get(r => r.CarId == rental.CarId);
            if (addedRent == null)
            {
                return new SuccessResult();
            }

            else
            {
                return new ErrorResult("Araba Zaten Kullanımda");
            }

        }











    }
}

