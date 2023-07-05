using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;


namespace ES.Model.Request
{
    public class FunctionDetailsRequest
    {
        [Required]
        public int CurrentPosition { get; set; }
        //[Required]
        //public bool EmergencyAlarm { get; set; }
        //[Required]
        //public bool Fan { get; set; }
        //[Required]
        //public bool FireAlarm { get; set; }
        //[Required]
        //public bool PowerStatus { get; set; }
    }
}
