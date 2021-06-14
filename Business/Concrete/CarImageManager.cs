using Backbone.Utilities.Results;
using Business.Abstract;
using Business.Constants;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        private ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        public IResult Delete(CarImage carImage)
        {
            var deletedImage = _carImageDal.Get(i => i.ImagePath == carImage.ImagePath);
            _carImageDal.Delete(deletedImage);
            return new SuccessResult(Messages.ImageDeleted);
        }

        public IResult Update(CarImage carImage)
        {
            _carImageDal.Update(carImage);
            return new SuccessResult(Messages.ImageUpdated);
        }
    }
}
