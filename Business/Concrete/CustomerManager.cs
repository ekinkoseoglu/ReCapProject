using Backbone.Utilities;
using Business.Abstract;
using Business.Constants;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using Backbone.Aspects.Autofac.Validation;
using Backbone.CrossCuttingConcerns.Validation;
using Backbone.Utilities.Results;
using Business.ValidationRules.FluentValidation;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        private ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public IResult Delete(int id)
        {
            if (DateTime.Now.Hour >= 22 & DateTime.Now.Hour <= 7)
            {
                return new ErrorResult(Messages.MaintenanceTime);
            }

            var deletedCustomer = _customerDal.Get(c => c.UserId == id);
            _customerDal.Delete(deletedCustomer);
            return new SuccessResult("Customer Deleted");
        }

        [ValidationAspect(typeof(CustomerValidator))]
        public IResult Add(Customer entity)
        {
            

            _customerDal.Add(entity);
            return new SuccessResult("Customer Added");
        }

        public IResult Update(Customer entity)
        {
            if (DateTime.Now.Hour >= 22 & DateTime.Now.Hour <= 7)
            {
                return new ErrorResult(Messages.MaintenanceTime);
            }
            _customerDal.Update(entity);
            return new SuccessResult("Customer Updated");
        }

        public IDataResult<Customer> Get(int id)
        {
            if (DateTime.Now.Hour >= 22 & DateTime.Now.Hour <= 7)
            {
                return new ErrorDataResult<Customer>(Messages.MaintenanceTime);
            }

            return new ErrorDataResult<Customer>(_customerDal.Get(p => p.UserId == id), "Customer Has Shown");
        }

        public IDataResult<List<Customer>> GetAll()
        {
            if (DateTime.Now.Hour >= 22 & DateTime.Now.Hour <= 7)
            {
                return new ErrorDataResult<List<Customer>>(Messages.MaintenanceTime);
            }

            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(), "All Customers Listed");
        }
    }
}
