using BAYSOFT.Core.Domain.Entities.MinecraftTraders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BAYSOFT.Core.Application.MinecraftTraders.Offers.Commands.PostOffer
{
    public class PostOfferCommand : ApplicationRequest<Offer, PostOfferCommandResponse>
    {
        public PostOfferCommand()
        {
        }
    }
}
