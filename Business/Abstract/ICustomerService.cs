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
   public interface ICustomerService
    {
        IResult Delete(int id);
        IResult Add(Customer entity);
        IResult Update(Customer entity);
        IDataResult<Customer> Get(int id);
        IDataResult<List<Customer>> GetAll();
    }
}
