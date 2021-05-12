using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;


namespace Business.Concrete
{
   public class BrandManager:IBrandService

   {
       private IBrandDal _brandDal;

       public BrandManager(IBrandDal brandDal)
       {
           _brandDal = brandDal;
       }

       public void Delete(int id)
       {
           var deletedBrand = _brandDal.Get(b => b.BrandId == id);
           _brandDal.Delete(deletedBrand);
       }

       

       public void Add(Brand entity)
       {
           _brandDal.Add(entity);
       }

       public void Update(Brand entity)
       {
           _brandDal.Update(entity);
       }

       public Brand Get(int id)
       {
           return _brandDal.Get(b=>b.BrandId==id);
       }

       public List<Brand> GetAll()
       {
           return _brandDal.GetAll();
       }
   }
}
