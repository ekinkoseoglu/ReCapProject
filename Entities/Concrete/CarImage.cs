using Backbone.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public class CarImage : IEntity
    {
        [Key]
        public int Id { get; set; }
        public int CarId { get; set; }
        public string ImageUrl { get; set; }
        public DateTime? Date { get; set; }
    }
}
