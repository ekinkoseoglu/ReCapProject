using Backbone.Entities.Concrete;
using System.Collections.Generic;

namespace Backbone.Utilities.Security.JWT
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(User user, List<OperationClaim> operationClaims);
    }
}
