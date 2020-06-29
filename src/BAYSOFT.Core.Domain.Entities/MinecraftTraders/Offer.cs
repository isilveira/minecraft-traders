namespace BAYSOFT.Core.Domain.Entities.MinecraftTraders
{
    public class Offer
    {
        public int OfferID { get; set; }
        public int Amount { get; set; }
        public int TradeID { get; set; }
        public Trade Trade { get; set; }
        public int ItemID { get; set; }
        public Item Item { get; set; }
        public Offer()
        {

        }
    }
}
