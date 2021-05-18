using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backbone.Entities;

namespace Entities.Concrete
{
    public class Customer:IEntity
    {
        public int UserId { get; set; }
        public string CompanyName { get; set; }
    }
}
