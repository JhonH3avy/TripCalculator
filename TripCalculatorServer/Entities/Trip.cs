using TypeGen.Core.TypeAnnotations;
namespace Entities
{
    [ExportTsClass(OutputDir = "../TripCalculatorApp/src/app/models")]
    public class Trip
    {
        public int Id { get; set; }
        public TripBag[] Bags { get; set; }
    }
}