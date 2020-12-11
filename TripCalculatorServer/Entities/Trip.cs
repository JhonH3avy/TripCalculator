using System.Collections.Generic;
using TypeGen.Core.TypeAnnotations;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace Entities
{
    [ExportTsInterface(OutputDir = "../TripCalculatorApp/src/app/models")]
    public class Trip
    {
        [TsOptional]
        public int Id { get; set; }
        public ICollection<TripBag> Bags { get; set; } = new List<TripBag>();

        [NotMapped]
        [TsIgnore]
        public int ElementsAmount => Bags.Sum(b => b.Elements.Count);

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}