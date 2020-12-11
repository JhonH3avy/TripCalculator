using System.ComponentModel.DataAnnotations.Schema;
using TypeGen.Core.TypeAnnotations;

namespace Entities
{
    [Table("TripElements")]
    [ExportTsInterface(OutputDir = "../TripCalculatorApp/src/app/models")]
    public class TripElement
    {
        [TsOptional]
        public int Id { get; set; }

        [TsOptional]
        public int Weight { get; set; }

        [TsIgnore]
        public DayOfWork DayOfWork { get; set; }

        [TsIgnore]
        public int DayOfWorkId { get; set; }
    }
}