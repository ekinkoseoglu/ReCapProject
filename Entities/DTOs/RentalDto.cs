using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backbone.Entities;

namespace Entities.DTOs
{
    public class RentalDto:IDto
    {
        public int Id { get; set; }
        public string BrandName { get; set; }
        public string  CustomerName { get; set; }
        public int CustomerId { get; set; }
        public int UserId { get; set; }

        public decimal DailyPrice { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}
