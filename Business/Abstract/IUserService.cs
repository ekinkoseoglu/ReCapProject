using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backbone.Utilities;
using Backbone.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
   public interface IUserService
    {
        IResult Delete(int id);
        IResult Add(User entity);
        IResult Update(User entity);
        IDataResult<User> Get(int id);
        IDataResult<List<User>> GetAll();
    }
}
