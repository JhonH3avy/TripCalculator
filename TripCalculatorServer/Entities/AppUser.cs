using System.ComponentModel.DataAnnotations;
using TypeGen.Core.TypeAnnotations;

namespace Entities
{
    [ExportTsClass(OutputDir = "../TripCalculatorApp/src/app/models")]
    public class AppUser
    {
        [Key]   
        public int IdentityNumber { get; set; }
    }
}