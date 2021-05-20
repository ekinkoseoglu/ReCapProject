﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backbone.DataAccess;
using Entities.Concrete;

namespace DataAccess.Abstract
{
   public interface IUserDal:IEntityRepository<User>
    {
    }
}