
using System.ComponentModel.DataAnnotations;

namespace ES.Model.Request
{
    public class PersonRequest
    {

        [Required]
        [MaxLength(100)]
        public string? Name { get; set; }

        [Required]
        [MaxLength(255)]
        public string? OfficeName { get; set; }

        [Required]
        [MaxLength(10)]
        public string? ContactNumber { get; set; }
    }
}
