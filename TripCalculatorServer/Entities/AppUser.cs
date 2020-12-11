using System.ComponentModel.DataAnnotations;
using TypeGen.Core.TypeAnnotations;

namespace Entities
{
    [ExportTsInterface(OutputDir = "../TripCalculatorApp/src/app/models")]
    public class AppUser
    {
        [TsOptional]
        public int Id { get; set; }

        [TsOptional]
        public string IdentityNumber { get; set; }
    }
}