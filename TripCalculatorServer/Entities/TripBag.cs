using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using TypeGen.Core.TypeAnnotations;
using System.Linq;

namespace Entities
{
    [ExportTsInterface(OutputDir = "../TripCalculatorApp/src/app/models")]
    public class TripBag
    {
        [TsOptional]
        public int Id { get; set; }
        public ICollection<TripElement> Elements { get; set; } = new List<TripElement>();

        [NotMapped]
        [TsIgnore]
        public int BagWeight => Elements.Sum(e => e.Weight);

        [NotMapped]
        [TsIgnore]
        public int AparentBagWeight => Elements.Count * (TopElement != null ? TopElement.Weight : 0);

        [NotMapped]
        [TsIgnore]
        public TripElement TopElement => Elements.FirstOrDefault(e => e.Weight == Elements.Max(e => e.Weight));

        [TsIgnore]
        public Trip Trip { get; set; }

        [TsIgnore]
        public int TripId { get; set; }
    }
}