using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using TypeGen.Core.TypeAnnotations;
using System.Linq;

namespace Entities
{
    [ExportTsClass(OutputDir = "../TripCalculatorApp/src/app/models")]
    public class TripBag
    {
        public int Id { get; set; }
        public ICollection<TripElement> Elements { get; set; }

        [NotMapped]
        public int BagWeight => Elements.Sum(e => e.Weight);

        [NotMapped]
        public int AparentBagWeight => Elements.Count() * TopElement.Weight;

        [NotMapped]
        public TripElement TopElement => Elements.FirstOrDefault(e => e.Weight == Elements.Max(e => e.Weight));

        public Trip Trip { get; set; }

        public int TripId { get; set; }
    }
}