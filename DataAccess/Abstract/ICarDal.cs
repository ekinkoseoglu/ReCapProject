using System;
using Backbone.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;
using System.Linq.Expressions;


namespace DataAccess.Abstract
{
    public interface ICarDal : IEntityRepository<Car>
    {

        List<CarDetailDto> GetCarDetails();
        List<CarDto> GetCarDto(Expression<Func<CarDto, bool>> filter = null);
        CarDto GetCarDtoById(Expression<Func<CarDto, bool>> filter = null);
    }
}
