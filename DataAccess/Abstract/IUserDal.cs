using Backbone.DataAccess;
using Entities.Concrete;
using System.Collections.Generic;
using Backbone.Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    {
        List<OperationClaim> GetClaims(User user); // join operation
    }
}
