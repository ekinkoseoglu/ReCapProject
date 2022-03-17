using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backbone.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ICreditCardService
    {
        public IDataResult<List<CreditCard>> GetAllCards();
        public IDataResult<List<CreditCard>> GetCardsByUserId(int id);
        public IResult AddCardForUser(CreditCard creditCard); 
        public IResult Delete(int id);
    }
}
