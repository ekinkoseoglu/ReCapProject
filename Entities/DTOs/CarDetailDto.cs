using Backbone.Entities;

namespace Entities.DTOs
{
    public class CarDetailDto : IDto
    {
        public int CarId { get; set; }
        public string BrandName { get; set; }
        public string Details { get; set; }
        public string ColorName { get; set; }
    }
}
