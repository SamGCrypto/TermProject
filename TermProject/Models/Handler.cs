using System.ComponentModel.DataAnnotations;

namespace TermProject.Models
{
    public class Handler
    {
        public int HandlerId { get; set; }
        public string HandlerName { get; set; } = string.Empty;
        public string HandlerDescription { get; set; } = string.Empty;
        public string HandlerType { get; set; } = string.Empty;
    }
}
