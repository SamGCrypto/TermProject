using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TermProject.Models
{
    public class MonsterType
    {
        [Key]
        public int MonsterTypeId {  get; set; }
        [Required(ErrorMessage ="Please enter a monster type")]
        [StringLength(500)]
        [Column]
        public string? Type {  get; set; }
        [Column]
        [Required(ErrorMessage = "Please enter in the description.")]
        [StringLength(500)]
        public string? TypeDescription {  get; set; }
    }
}
