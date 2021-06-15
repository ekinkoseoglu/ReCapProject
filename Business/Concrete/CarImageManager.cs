using Backbone.Utilities.Results;
using Business.Abstract;
using Business.Constants;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        private ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        public IResult Add(IFormFile file, CarImage carImage)
        {
            throw new System.NotImplementedException();
        }

        public IResult Update(IFormFile file, CarImage carImage)
        {
            throw new System.NotImplementedException();
        }

        public IResult Delete(CarImage carImage)
        {
            throw new System.NotImplementedException();
        }
    }
}
