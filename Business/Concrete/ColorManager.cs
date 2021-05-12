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
   public class ColorManager:IColorService
   {
       private IColorDal _colorDal;

       public ColorManager(IColorDal colorDal)
       {
           _colorDal = colorDal;
       }

       public void Delete(int id)
       {
           var deletedColor = _colorDal.Get(c => c.ColorId == id);
           _colorDal.Delete(deletedColor);
       }

      

       public void Add(Color entity)
        {
            _colorDal.Add(entity);
        }

        public void Update(Color entity)
        {
            _colorDal.Update(entity);
        }

        public Color Get(int id)
        {
            return _colorDal.Get(c => c.ColorId == id);
        }

        public List<Color> GetAll()
        {
            return _colorDal.GetAll();
        }
    }
}
