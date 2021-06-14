using Backbone.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        public IResult Delete(CarImage carImage);
        public IResult Update(CarImage carImage);
    }
}
