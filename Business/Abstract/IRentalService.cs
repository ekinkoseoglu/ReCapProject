using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backbone.Utilities;
using Backbone.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IResult Delete(int id);
        IResult Add(Rental entity);
        IResult Update(Rental entity);
        IDataResult<Rental> Get(int id);
        IDataResult<List<Rental>> GetAll();
        IDataResult<List<RentalDto>> GetRentalDetails();
    }
}
