using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backbone.Utilities;
using Backbone.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IBrandService

    {
        IResult Delete(int id);
        IResult Add(Brand entity);
        IResult Update(Brand entity);
        IDataResult<Brand> Get(int id);
        IDataResult<List<Brand>> GetAll();

    }
}
