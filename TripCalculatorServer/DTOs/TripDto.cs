using System.Collections.Generic;
using System;

namespace DTOs
{
    public class TripDto
    {
        public int Id { get; set; }
        public ICollection<TripBagDto> Bags { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}