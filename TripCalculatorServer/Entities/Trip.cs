using TypeGen.Core.TypeAnnotations;

namespace Entities
{
    [ExportTsClass]
    public class Trip
    {
        public int Id { get; set; }
        public TripBag[] Bags { get; set; }
    }
}