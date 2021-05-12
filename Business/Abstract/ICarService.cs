using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface ICarService

    {
        void Delete(int id);
        void Add(Car entity);
        void Update(Car entity);
        Car Get(int id);
        List<CarDetailDto> GetCarDetails();
        List<Car> GetAll();

        List<Car> GetAllByColorId(int id);

        List<Car> GetAllByPrice(int min, int max);
    }
}
