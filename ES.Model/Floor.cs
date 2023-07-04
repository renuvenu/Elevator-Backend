using System.ComponentModel.DataAnnotations;

namespace ES.Model
{
    public class Floor
    {
        public Guid Id { get; set; }

        [Required]
        public int FloorNum { get; set; }
    }
}
