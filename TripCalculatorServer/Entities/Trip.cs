using System.Collections.Generic;
using TypeGen.Core.TypeAnnotations;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    [ExportTsClass(OutputDir = "../TripCalculatorApp/src/app/models")]
    public class Trip
    {
        public int Id { get; set; }
        public ICollection<TripBag> Bags { get; set; }

        [NotMapped]
        public int ElementsAmount => Bags.Sum(b => b.Elements.Count);
    }
}