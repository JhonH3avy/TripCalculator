using System.Collections.Generic;
using TypeGen.Core.TypeAnnotations;
using System;

namespace Entities
{
    [ExportTsClass(OutputDir = "../TripCalculatorApp/src/app/models")]
    public class DayOfWork
    {
        public DayOfWork()
        {
            CreatedAt = DateTime.UtcNow;
        }

        public int Id { get; set; }

        public ICollection<TripElement> Elements { get; set; }

        public AppUser User { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}