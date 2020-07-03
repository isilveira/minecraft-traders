namespace BAYSOFT.Core.Domain.Entities.MinecraftTraders
{
    public class Accept
    {
        public int AcceptID { get; set; }
        public int Amount { get; set; }
        public int TradeID { get; set; }
        public Trade Trade { get; set; }
        public int ItemID { get; set; }
        public Item Item { get; set; }
        public Accept()
        {

        }

        public Accept(int amount, int itemID)
        {
            Amount = amount;
            ItemID = itemID;
        }
        public Accept(int amount, Item item)
        {
            Amount = amount;
            ItemID = item.ItemID;
        }
    }
}
