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
   public interface IColorService
    {
        IResult Delete(int id);
        IResult Add(Color entity);
        IResult Update(Color entity);
        IDataResult<Color> Get(int id);
        IDataResult<List<Color>> GetAll();
    }
}
