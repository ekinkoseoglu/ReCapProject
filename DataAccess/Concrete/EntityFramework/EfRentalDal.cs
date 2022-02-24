using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Backbone.DataAccess.EntityFramework;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal:EfEntityRepositoryBase<Rental,RentingCarDBContext>,IRentalDal
    {
        public List<RentalDto> GetRentalDetails(Expression<Func<RentalDto,bool>> filter = null)
        {
            using (RentingCarDBContext context = new RentingCarDBContext())
            {
                var result = from r in context.Rentals
                    join c in context.Cars on r.CarId equals c.Id
                    join cus in context.Customers on r.CustomerId equals cus.Id
                    join u in context.Users on cus.UserId equals u.Id
                    join b in context.Brands on c.BrandId equals b.Id
                    join col in context.Colours on c.ColorId equals col.Id

                    select new RentalDto()
                    {
                        Id = r.Id,
                        BrandName = b.Name,
                        CustomerName = u.FirstName+" "+u.LastName,
                        CustomerId = cus.Id,
                        UserId = u.Id,
                        DailyPrice = c.DailyPrice,
                        RentDate = r.RentDate,
                        ReturnDate = r.ReturnDate


                    };

                return filter is null ? result.ToList() : result.Where(filter).ToList();
            }

        }
    }
}
