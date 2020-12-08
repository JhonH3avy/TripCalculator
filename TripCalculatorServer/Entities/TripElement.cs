using TypeGen.Core.TypeAnnotations;

namespace Entities
{
    [ExportTsClass(OutputDir = "../TripCalculatorApp/src/app/models")]
    public class TripElement
    {
        public int Id { get; set; }
        public int Weight { get; set; }
    }
}