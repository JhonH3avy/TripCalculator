using TypeGen.Core.TypeAnnotations;

namespace Entities
{
    [ExportTsClass]
    public class DayOfWork
    {
        public int Id { get; set; }

        public TripElement[] Elements { get; set; }
    }
}