using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ICarService
    {
        Car Get(int id);
        List<Car> GetAll();

        List<Car> GetAllByColorId(int id);

        List<Car> GetAllByPrice(int min, int max);
    }
}
