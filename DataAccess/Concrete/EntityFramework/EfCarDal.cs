using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Backbone.DataAccess.EntityFramework;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RentingCarDBContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (RentingCarDBContext context = new RentingCarDBContext())
            {
                var result = from c in context.Cars
                    join col in context.Colours
                       
                        on c.ColorId equals col.Id
                    join b in context.Brands
                        on c.BrandId equals b.Id
                    select new CarDetailDto
                    {
                        CarId = c.Id,
                        ColorName = col.Name,
                        Details = c.Description,
                        BrandName = b.Name
                    };
                return result.ToList();
            }
        }

        public List<CarDto> GetCarDto()
        {
            using (RentingCarDBContext context =new RentingCarDBContext())
            {
                var result = from c in context.Cars
                    join b in context.Brands
                        on c.BrandId equals b.Id

                    join col in context.Colours
                        on c.ColorId equals col.Id

                    select new CarDto
                    {
                        Id = c.Id,
                        CarName = c.CarName,
                        ColorName = col.Name,
                        BrandName = b.Name,
                        DailyPrice = c.DailyPrice,
                        ModelYear = c.ModelYear,
                        Description = c.Description
                    };
                return result.ToList();

            }
        }
    }
}
