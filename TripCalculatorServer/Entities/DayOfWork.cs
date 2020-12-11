using System.Collections.Generic;
using TypeGen.Core.TypeAnnotations;

namespace Entities
{
    [ExportTsClass(OutputDir = "../TripCalculatorApp/src/app/models")]
    public class DayOfWork
    {
        public int Id { get; set; }

        public ICollection<TripElement> Elements { get; set; }

        public AppUser User { get; set; }
    }
}