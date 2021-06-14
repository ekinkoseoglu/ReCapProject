using Backbone.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ICarService

    {
        IResult Delete(int id);

        IResult Add(Car entity);
        IResult Update(Car entity);
        IDataResult<Car> Get(int id);
        IDataResult<List<CarDetailDto>> GetCarDetails();
        IDataResult<List<Car>> GetAll();

        IDataResult<List<Car>> GetAllByColorId(int id);

        IDataResult<List<Car>> GetAllByPrice(int min, int max);
    }
}
