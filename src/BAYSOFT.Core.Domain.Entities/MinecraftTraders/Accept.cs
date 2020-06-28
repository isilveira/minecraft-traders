using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace BAYSOFT.Core.Domain.Entities.MinecraftTraders
{
    public class Accept
    {
        public int AcceptID { get; set; }
        public int Amount { get; set; }
        public Trade Trade { get; set; }
        public Item Item { get; set; }
        public Accept()
        {

        }
    }
}
