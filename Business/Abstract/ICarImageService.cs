using Backbone.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IResult Add(IFormFile file, CarImage carImage);

        IResult Update(IFormFile file, CarImage carImage);
        IResult Delete(CarImage carImage);

        IDataResult<List<CarImage>> GetAll();

        IDataResult<CarImage> GetByImageId(int imageId);
        IDataResult<List<CarImage>> GetByCarId(int carId);
    }
}
