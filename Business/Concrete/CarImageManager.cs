using Backbone.Utilities.Helpers;
using Backbone.Utilities.Results;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        private ICarImageDal _carImageDal;
        private IFileHelper _fileHelper;

        public CarImageManager(ICarImageDal carImageDal, IFileHelper fileHelper)
        {
            _carImageDal = carImageDal;
            _fileHelper = fileHelper;
        }

        public IResult Add(IFormFile file, CarImage carImage)
        {
            carImage.ImagePath = _fileHelper.Add(file);
            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage);
            return new SuccessResult();
        }

        public IResult Update(IFormFile file, CarImage carImage)
        {
            carImage.ImagePath = _fileHelper.Update(_carImageDal.Get(c => c.ImageId == carImage.ImageId).ImagePath, file);
            carImage.Date = DateTime.Now;
            _carImageDal.Update(carImage);
            return new SuccessResult();
        }

        public IResult Delete(CarImage carImage)
        {
            _fileHelper.Delete(carImage.ImagePath);
            _carImageDal.Delete(carImage);
            return new SuccessResult();
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IDataResult<CarImage> GetByImageId(int ImageId)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(c => c.ImageId == ImageId));
        }

        public IDataResult<List<CarImage>> GetByCarId(int carId)
        {
            return new SuccessDataResult<List<CarImage>>(ShowDefaulImage(carId));
        }



        /*-------------------------------------------------------------------------------*/







        private List<CarImage> ShowDefaulImage(int carId)
        {
            string path = @"C:\Users\ekind\Desktop\RentACarLogo\logo2.jpg";
            var result = _carImageDal.GetAll(c => c.CarId == carId).Any(); // Datadan girilen CarId ile uyuşan CarImage var mı kontrol et  

            if (result) // Eğer Car Id'si ile uyumlu bir Image ya da Imageler varsa onları göster
            {
                return new List<CarImage>(_carImageDal.GetAll(c => c.CarId == carId));
            }
            // Eğer yoksa...


            List<CarImage> carImages = new List<CarImage>(); // Girilen araba Id sinin içine Şirket logosunu kaydet ve göster
            carImages.Add(new CarImage { CarId = carId, ImagePath = path, Date = DateTime.Now });
            return new List<CarImage>(carImages);

        }
    }
}
