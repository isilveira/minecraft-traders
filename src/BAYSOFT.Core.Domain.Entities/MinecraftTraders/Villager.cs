using System.Collections.Generic;

namespace BAYSOFT.Core.Domain.Entities.MinecraftTraders
{
    public class Villager
    {
        public int VillagerID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Profession Profession { get; set; }
        public ICollection<Trade> Trades { get; set; }
        public Villager()
        {
            Trades = new HashSet<Trade>();
        }
    }
}
