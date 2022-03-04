using Backbone.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ICarService

    {
        IResult Add(Car entity);
        IResult Delete(int id);
        IResult Update(Car entity);

        /*------------------GET METHODS ------------------------------*/

        IDataResult<Car> Get(int id);
        IDataResult<List<Car>> GetAll();
        IDataResult<List<Car>> GetAllByColorId(int id);
        IDataResult<List<Car>> GetAllByBrandId(int id);
        IDataResult<List<Car>> GetAllByPrice(int min, int max);

        /*----------------------DTO METHODS---------------------------------*/
        IDataResult<List<CarDto>> GetCarDetails();
        IDataResult<List<CarDto>> GetAllDtosByColorId(int id);
        IDataResult<List<CarDto>> GetAllDtosByBrandId(int id);
    }
}
