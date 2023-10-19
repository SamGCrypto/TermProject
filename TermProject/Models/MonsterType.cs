using System.ComponentModel.DataAnnotations;


namespace TermProject.Models
{
    public class MonsterType
    {
        public int MonsterTypeId {  get; set; }
        
        public string? Type {  get; set; }
        public string? TypeDescription {  get; set; }
    }
}
