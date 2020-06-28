using System;
using System.Collections.Generic;
using System.Text;

namespace BAYSOFT.Core.Domain.Entities.MinecraftTraders
{
    public class Item
    {
        public int ItemID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Accept> Accepts { get; set; }
        public ICollection<Offer> Offers { get; set; }
        public ICollection<ProfessionItem> ProfessionItems { get; set; }
        public Item()
        {
            Accepts = new HashSet<Accept>();
            Offers = new HashSet<Offer>();
            ProfessionItems = new HashSet<ProfessionItem>();
        }
    }
}
