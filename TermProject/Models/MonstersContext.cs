using Microsoft.EntityFrameworkCore;

namespace TermProject.Models
{
    public class MonstersContext:DbContext
    {
        public MonstersContext(DbContextOptions<MonstersContext> options):base(options) { }

        public DbSet<Monsters> Monsters { get; set; }
        public DbSet<Handler> Handler { get; set; }
        public DbSet<MonsterType> MonsterTypes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Handler>().HasData(
                new Handler
                {
                    HandlerId = 1,
                    HandlerName = "David Bowie",
                    HandlerDescription = "Starman",
                    HandlerType = "Cosmic"
                },
                new Handler
                {
                    HandlerId = 2,
                    HandlerName = "Mercury, Freddy",
                    HandlerDescription = "Queen",
                    HandlerType = "Royal"
                },
                new Handler
                {
                    HandlerId = 3,
                    HandlerName = "Tom and Jerry",
                    HandlerDescription = "Toons",
                    HandlerType = "Toon physics specialist"
                }
                );

            modelBuilder.Entity<MonsterType>().HasData(
                new MonsterType
                {
                    MonsterTypeId = 1,
                    Type = "Holy",
                    TypeDescription = "Holy type arcana, typically former priests of religion."
                }, new MonsterType
                {
                    MonsterTypeId = 2,
                    Type = "Cosmic",
                    TypeDescription = "Usually Celestial being, usually requires space travel to fight"
                }, new MonsterType
                {
                    MonsterTypeId = 3,
                    Type = "Infernal",
                    TypeDescription = "These entities usually are from hell or have a connection to it."
                });



            modelBuilder.Entity<Monsters>().HasData(new Monsters
            {
                Id = 1,
                MonsterName = "Mothman",
                MonsterCount = 1,
                MonsterThreatLvl = 3,
                HandlerId = 2,
                MonsterTypeId=2

            }, new Monsters
            {
                Id = 2,
                MonsterName = "Kaiju",
                MonsterCount = 2,
                MonsterThreatLvl = 5,
                HandlerId = 1, 
                MonsterTypeId=3

            }, new Monsters
            {
                Id = 3,
                MonsterName = "Poltergeist",
                MonsterCount = 201,
                MonsterThreatLvl = 2,
                HandlerId = 3,
                MonsterTypeId = 1
            }, new Monsters
            {
                Id = 4,
                MonsterName = "Grim Grinning Ghosts Gang",
                MonsterCount = 999,
                MonsterThreatLvl = 1,
                HandlerId = 3, 
                MonsterTypeId = 1

            }); ;
        }
               
    }
}
