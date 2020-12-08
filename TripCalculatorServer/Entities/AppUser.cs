using System.ComponentModel.DataAnnotations;
using TypeGen.Core.TypeAnnotations;

namespace Entities
{
    [ExportTsClass(OutputDir = "../TripCalculatorApp/src/app/models")]
    public class AppUser
    {
        public int Id { get; set; }
        public string IdentityNumber { get; set; }
    }
}