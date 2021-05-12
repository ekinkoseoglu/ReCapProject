using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IBrandService

    {
        void Delete(int id);
        void Add(Brand entity);
        void Update(Brand entity);
        Brand Get(int id);
        List<Brand> GetAll();

    }
}
