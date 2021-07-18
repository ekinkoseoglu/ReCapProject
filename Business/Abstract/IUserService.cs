using Backbone.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;
using Backbone.Entities.Concrete;

namespace Business.Abstract
{
    public interface IUserService
    {
        IResult Delete(int id);
        IResult Add(User entity);
        IResult Update(User entity);
        IDataResult<User> Get(int id);
        IDataResult<List<User>> GetAll();
        IDataResult<List<OperationClaim>> GetClaims(User user);
        IDataResult<User> GetByMail(string email);


    }
}
