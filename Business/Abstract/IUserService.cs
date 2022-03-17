using Backbone.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;
using Backbone.Entities.Concrete;

namespace Business.Abstract
{
    public interface IUserService
    {
        IDataResult<List<User>> GetAll();
        IDataResult<User> Get(int id);
        IResult Add(User user);
        IResult Update(User entity);
        IResult Delete(int id);
        User GetByMail(string email);
        List<OperationClaim> GetClaims(User user);
        
        

    }
}
