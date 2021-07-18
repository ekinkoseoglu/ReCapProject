using Backbone.Aspects.Autofac.Validation;
using Backbone.Utilities.Business;
using Backbone.Utilities.Results;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using Backbone.Entities.Concrete;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        private IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IResult Delete(int id)
        {
            if (DateTime.Now.Hour > 22 && DateTime.Now.Hour < 9)
            {
                return new ErrorResult(Messages.MaintenanceTime);
            }

            var deletedUser = _userDal.Get(u => u.UserId == id);
            _userDal.Delete(deletedUser);
            return new SuccessResult("User Deleted");
        }

        [ValidationAspect(typeof(UserValidator))]
        public IResult Add(User entity)
        {
            var result = BusinessRules.Run(CheckEMail(entity.Email));

            if (result != null)
            {
                return result;
            }

            _userDal.Add(entity);
            return new SuccessResult("User Added");
        }

        public IResult Update(User entity)
        {
            if (DateTime.Now.Hour > 22 && DateTime.Now.Hour < 9)
            {
                return new ErrorResult(Messages.MaintenanceTime);
            }
            _userDal.Update(entity);
            return new SuccessResult("User Updated");
        }

        public IDataResult<User> Get(int id)
        {
            if (DateTime.Now.Hour > 22 && DateTime.Now.Hour < 9)
            {
                return new ErrorDataResult<User>(Messages.MaintenanceTime);
            }

            return new SuccessDataResult<User>(_userDal.Get(u => u.UserId == id), "User Has Shown");
        }

        public IDataResult<List<User>> GetAll()
        {
            if (DateTime.Now.Hour > 22 && DateTime.Now.Hour < 9)
            {
                return new ErrorDataResult<List<User>>(Messages.MaintenanceTime);
            }

            return new SuccessDataResult<List<User>>(_userDal.GetAll(), "Listed All Users");
        }

        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            var result = _userDal.GetClaims(user);
            return new SuccessDataResult<List<OperationClaim>>(result);
        }

        public IDataResult<User> GetByMail(string email)
        {
            var result = _userDal.Get(u => u.Email == email);

            return new SuccessDataResult<User>(result);
        }


        /* ----------------------BUSINESS RULES-------------------------------*/



        private IResult CheckEMail(string email)
        {
            var emailCheck = _userDal.GetAll(u => u.Email == email).Any();
            if (emailCheck)
            {
                return new ErrorResult("Bu Mail Adresi Zaten Mevcut");
            }

            return new SuccessResult();
        }


    }
}
