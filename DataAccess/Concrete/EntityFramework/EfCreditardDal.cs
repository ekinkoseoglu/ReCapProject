using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backbone.DataAccess.EntityFramework;
using Backbone.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCreditardDal : EfEntityRepositoryBase<CreditCard,RentingCarDBContext>,ICreditCardDal
    {
        
    }
}
