using System.Collections.Generic;
using TypeGen.Core.TypeAnnotations;
using System;

namespace Entities
{
    [ExportTsInterface(OutputDir = "../TripCalculatorApp/src/app/models")]
    public class DayOfWork
    {
        [TsOptional]
        public int Id { get; set; }

        public ICollection<TripElement> Elements { get; set; } = new List<TripElement>();

        [TsOptional]
        public AppUser User { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}