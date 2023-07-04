using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Model
{
    public class PersonDetailsInLift
    {
        public Guid Id { get; set; }
        public string PersonId { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Weight { get; set; }
        public int FromFloorNum { get; set;}
        public int ToFloorNum { get; set;}
        public string Status { get; set;}
    }
}
