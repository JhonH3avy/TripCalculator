using System.ComponentModel.DataAnnotations.Schema;
using TypeGen.Core.TypeAnnotations;

namespace Entities
{
    [Table("TripElements")]
    [ExportTsClass(OutputDir = "../TripCalculatorApp/src/app/models")]
    public class TripElement
    {
        public int Id { get; set; }
        public int Weight { get; set; }

        public DayOfWork DayOfWork { get; set; }

        public int DayOfWorkId { get; set; }
    }
}