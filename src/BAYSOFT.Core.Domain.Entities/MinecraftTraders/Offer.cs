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
        public Offer(int amount, int itemID)
        {
            this.Amount = amount;
            this.ItemID = itemID;
        }

        public Offer(int amount, Item item)
        {
            this.Amount = amount;
            this.ItemID = item.ItemID;
        }
    }
}
