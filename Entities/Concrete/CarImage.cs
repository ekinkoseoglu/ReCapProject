using Backbone.Entities;
using System;

namespace Entities.Concrete
{
    public class CarImage : IEntity
    {

        public Guid Id { get; set; }
        public int CarId { get; set; }
        public string ImagePath { get; set; }
        public DateTime Date { get; set; }
    }
}
