using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backbone.Entities;

namespace Entities.DTOs
{
    public class CarDto:IDto
    {
        public int Id { get; set; }
        public string CarName { get; set; }
        public int BrandId { get; set; }    
        public string BrandName { get; set; }
        public int ColorId { get; set; }
        public string ColorName { get; set; }
        public string ModelYear { get; set; }
        public decimal DailyPrice { get; set; }
        public string Description { get; set; }

    }
}
