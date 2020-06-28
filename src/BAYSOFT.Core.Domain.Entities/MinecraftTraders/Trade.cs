using System;
using System.Collections.Generic;
using System.Text;

namespace BAYSOFT.Core.Domain.Entities.MinecraftTraders
{
    public class Trade
    {
        public int TradeID { get; set; }
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
