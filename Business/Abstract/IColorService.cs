using Backbone.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;

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
