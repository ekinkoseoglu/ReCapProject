using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;

namespace Business.Abstract
{
   public interface IColorService
    {
        void Delete(int id);
        void Add(Color entity);
        void Update(Color entity);
        Color Get(int id);
        List<Color> GetAll();
    }
}
