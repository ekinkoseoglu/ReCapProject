using Backbone.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;
using Backbone.Entities.Concrete;

namespace Business.Abstract
{
    public interface IUserService
    {
        IResult Delete(int id);
        List<OperationClaim> GetClaims(User user);
        IResult Add(User user);
        User GetByMail(string email);
        IResult Update(User entity);
        IDataResult<User> Get(int id);
        IDataResult<List<User>> GetAll();
        
        

    }
}
