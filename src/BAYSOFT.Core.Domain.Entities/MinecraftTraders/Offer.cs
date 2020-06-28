using System;
using System.Collections.Generic;
using System.Text;

namespace BAYSOFT.Core.Domain.Entities.MinecraftTraders
{
    public class Offer
    {
        public int OfferID { get; set; }
        public int Amount { get; set; }
        public Trade Trade { get; set; }
        public Item Item { get; set; }
        public Offer()
        {

        }
    }
}
