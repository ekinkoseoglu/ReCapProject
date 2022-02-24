using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Backbone.DataAccess;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Abstract
{
    public interface IRentalDal : IEntityRepository<Rental>
    {
        List<RentalDto> GetRentalDetails(Expression<Func<RentalDto, bool>> filter = null);
    }
}
