using System.Collections.Generic;

namespace DTOs
{
    public class TripBagDto
    {
         public int Id { get; set; }
        public ICollection<TripElementDto> Elements { get; set; }
    }
}