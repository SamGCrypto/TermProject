using System.ComponentModel.DataAnnotations;

namespace TermProject.Models
{
    public class Handler
    {
        [Key]
        public int HandlerId { get; set; }
        [Required(ErrorMessage ="Please enter in Handler's name")]
        public string HandlerName { get; set; } = string.Empty;
        public string HandlerDescription { get; set; } = string.Empty;
        public string HandlerType { get; set; } = string.Empty;
    }
}
