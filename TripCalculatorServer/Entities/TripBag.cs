using TypeGen.Core.TypeAnnotations;

namespace Entities
{
    [ExportTsClass(OutputDir = "../TripCalculatorApp/src/app/models")]
    public class TripBag
    {
        public int Id { get; set; }
        public TripElement[] Elements { get; set; }

        public Trip Trip { get; set; }

        public int TripId { get; set; }
    }
}