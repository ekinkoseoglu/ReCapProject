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

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        private ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        [CacheRemoveAspect("ICustomerService.Get")]
        public IResult Delete(int id)
        {
            if (DateTime.Now.Hour >= 22 & DateTime.Now.Hour <= 7)
            {
                return new ErrorResult(Messages.MaintenanceTime);
            }

            var deletedCustomer = _customerDal.Get(c => c.Id == id);
            _customerDal.Delete(deletedCustomer);
            return new SuccessResult("Customer Deleted");
        }

        [CacheRemoveAspect("ICustomerService.Get")]
        [ValidationAspect(typeof(CustomerValidator))]
        public IResult Add(Customer entity)
        {


            _customerDal.Add(entity);
            return new SuccessResult("Customer Added");
        }

        [CacheRemoveAspect("ICustomerService.Get")]
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

            return new ErrorDataResult<Customer>(_customerDal.Get(p => p.Id == id), "Customer Has Shown");
        }

        [CacheAspect()]
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
