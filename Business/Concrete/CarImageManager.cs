using Backbone.Aspects.Autofac.Validation;
using Backbone.Utilities.Business;
using Backbone.Utilities.Helpers;
using Backbone.Utilities.Results;
using Business.Abstract;
using Business.ValidationRules.FluentValidation;
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
        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(IFormFile file, CarImage carImage)
        {

            IResult result = BusinessRules.Run(CarImageLimit(carImage.CarId));


            if (result != null)
            {
                return result;
            }


            carImage.ImageUrl = _fileHelper.Add(file);
            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage);
            return new SuccessResult();
        }

        public IResult Update(IFormFile file, CarImage carImage)
        {
            carImage.ImageUrl = _fileHelper.Update(_carImageDal.Get(c => c.Id == carImage.Id).ImageUrl, file);
            carImage.Date = DateTime.Now;
            _carImageDal.Update(carImage);
            return new SuccessResult();
        }

        public IResult Delete(CarImage carImage)
        {
            _fileHelper.Delete(carImage.ImageUrl);
            _carImageDal.Delete(carImage);
            return new SuccessResult();
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IDataResult<CarImage> GetByImageId(int imageId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<CarImage> GetById(int Id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(c => c.Id == Id));
        }

        public IDataResult<List<CarImage>> GetByCarId(int carId)
        {
            var result = BusinessRules.Run(CarIdExist(carId));
            if (result != null)
            {
                return new ErrorDataResult<List<CarImage>>(result.Message);
            }

            return new SuccessDataResult<List<CarImage>>(ShowDefaulImage(carId));
        }





        /*--------------------------------BUSINESS RULES------------------------------------*/




        private IDataResult<List<CarImage>> CarIdExist(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId).Any();

            if (!result)
            {
                return new ErrorDataResult<List<CarImage>>("Mevcut Arabanın Id'sini Yazmak Zorundasınız");
            }

            return new SuccessDataResult<List<CarImage>>();

        }


        private List<CarImage> ShowDefaulImage(int carId)
        {
            string path = @"C:\Users\ekind\Desktop\RentACarLogo\logo2.jpg".Replace("\\", "/");

            var result = _carImageDal.GetAll(c => c.CarId == carId).Any(); // Datadan girilen CarId ile uyuşan CarImage var mı kontrol et  

            if (result) // Eğer Car Id'si ile uyumlu bir Image ya da Imageler varsa onları göster
            {
                return new List<CarImage>(_carImageDal.GetAll(c => c.CarId == carId));
            }
            // Eğer yoksa...


            List<CarImage> carImages = new List<CarImage>(); // Girilen araba Id sinin içine Şirket logosunu kaydet ve göster
            carImages.Add(new CarImage { CarId = carId, ImageUrl = path, Date = DateTime.Now });
            return new List<CarImage>(carImages);

        }

        private IResult CarImageLimit(int carId)
        {
            var carImages = _carImageDal.GetAll(c => c.CarId == carId).Count;
            if (carImages >= 5)
            {
                return new ErrorResult("Mevcut Arabaya en fazla 5 görsel ekleyebilirsiniz.");
            }

            return new SuccessResult();
        }
    }
}
