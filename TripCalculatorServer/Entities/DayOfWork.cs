using TypeGen.Core.TypeAnnotations;

namespace Entities
{
    [ExportTsClass(OutputDir = "../TripCalculatorApp/src/app/models")]
    public class DayOfWork
    {
        public int Id { get; set; }

        public TripElement[] Elements { get; set; }

        public AppUser User { get; set; }
    }
}