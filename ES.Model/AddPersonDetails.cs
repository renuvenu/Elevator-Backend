
using System.ComponentModel.DataAnnotations.Schema;

namespace ES.Model
{
    public class AddPersonDetails
    {
        public string PersonId { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Weight { get; set; }
        public int FromFloorNum { get; set; }
        public int ToFloorNum { get; set; }
        public string Status { get; set; }
    }
}
