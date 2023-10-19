using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TermProject.Models
{
    public class Monsters
    {
        //EF will instruct the database to automatically generate this value
        public int Id { get; set; }
        [Required(ErrorMessage="List a monsters name")]
        public string MonsterName { get; set;}
        [Required(ErrorMessage ="Please enter the amount of monsters")]
        [Range(1,1000, ErrorMessage ="Please enter an amount between 1 and 1000, if there is more alert emergency personnel")]
        public int? MonsterCount { get; set; }
        [Required(ErrorMessage = "Please enter in threat level rating")]
        [Range(1, 10, ErrorMessage = "Rating must be between one and ten.")]
        public int? MonsterThreatLvl {  get; set; }

        [ForeignKey("MonsterType")]
        public int MonsterTypeId {  get; set; }
        public MonsterType? MonsterType { get; set; }
        public MonsterType? Type { get; set; }
        public MonsterType? TypeDescription { get; set; }

        [ForeignKey("Handler")]
        public int HandlerId { get; set; }
        public Handler? Handler { get; set; }
        public Handler? HandlerName { get; set; }
        public Handler? HandlerDescription {  get; set; }
        public Handler? HandlerType { get; set; }


        public string Slug => MonsterName?.Replace(' ','-').ToLower()+"-"+MonsterCount?.ToString();


    }
}
