
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ES.Model.Request
{
    public class PersonDetailsRequest
    {
        [Required]
        public string PersonId { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Weight { get; set; }

        [Required]
        public int FromFloorNum { get; set; }

        [Required]
        public int ToFloorNum { get; set; }

        [Required]
        public string Status { get; set; }
    }
}
