using System.Collections.Generic;

namespace BAYSOFT.Core.Domain.Entities.MinecraftTraders
{
    public class Trade
    {
        public int TradeID { get; set; }
        public int VillagerID { get; set; }
        public Villager Villager { get; set; }
        public ICollection<Accept> Accepts { get; set; }
        public ICollection<Offer> Offers { get; set; }
        public Trade()
        {
            Accepts = new HashSet<Accept>();
            Offers = new HashSet<Offer>();
        }
    }
}
