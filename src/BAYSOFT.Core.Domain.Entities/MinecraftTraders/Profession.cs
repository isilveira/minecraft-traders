using System.Collections.Generic;

namespace BAYSOFT.Core.Domain.Entities.MinecraftTraders
{
    public class Profession
    {
        public int ProfessionID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Default { get; set; }
        public int Order { get; set; }
        public ICollection<Villager> Villagers { get; set; }
        public ICollection<ProfessionItem> ProfessionItems { get; set; }
        public Profession()
        {
            Villagers = new HashSet<Villager>();
            ProfessionItems = new HashSet<ProfessionItem>();
        }
    }
}
