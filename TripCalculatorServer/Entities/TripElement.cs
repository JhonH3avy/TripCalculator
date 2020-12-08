using TypeGen.Core.TypeAnnotations;

namespace Entities
{
    [ExportTsClass]
    public class TripElement
    {
        public int Id { get; set; }
        public int Weight { get; set; }
    }
}