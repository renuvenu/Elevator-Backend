using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Model
{
    public class PersonDetailsInLift
    {
        public Guid Id { get; set; }

        [Required]
        public string? PersonId { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Weight { get; set; }

        [Required]
        public int FromFloorNum { get; set;}

        [Required]
        public int ToFloorNum { get; set;}

        [Required]
        public String? TravelledDateTime { get; set; }

        [Required]
        public string? Status { get; set;}

    }
}
