namespace BAYSOFT.Core.Domain.Entities.MinecraftTraders
{
    public class ProfessionItem
    {
        public int ProfessionID { get; set; }
        public int ItemID { get; set; }
        public Profession Profession { get; set; }
        public Item Item { get; set; }
        public ProfessionItem()
        {
        }
    }
}
