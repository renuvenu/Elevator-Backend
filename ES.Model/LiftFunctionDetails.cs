using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Model
{
    public class LiftFunctionDetails
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public int CurrentPostion { get; set; }
        [Required]
        public bool EmergencyAlarm { get; set; }
        [Required]
        public bool Fan { get; set; }
        [Required]
        public bool FireAlarm{get;set;}
        [Required]
        public bool PowerStatus { get; set; }
    }
}
