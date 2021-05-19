using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backbone.Utilities;
using Business.Abstract;
using Business.Constants;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class UserManager:IUserService
    {
        private IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IResult Delete(int id)
        {
            if (DateTime.Now.Hour >22 && DateTime.Now.Hour <9)
            {
                return new ErrorResult(Messages.MaintenanceTime);
            }

            var deletedUser = _userDal.Get(u => u.UserId == id);
            _userDal.Delete(deletedUser);
            return new SuccessResult("User Deleted");
        }

        public IResult Add(User entity)
        {
            if (DateTime.Now.Hour > 22 && DateTime.Now.Hour < 9)
            {
                return new ErrorResult(Messages.MaintenanceTime);
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
    }
}
