using BAYSOFT.Core.Domain.Entities.MinecraftTraders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BAYSOFT.Core.Application.MinecraftTraders.Offers.Commands.PatchOffer
{
    public class PatchOfferCommand : ApplicationRequest<Offer, PatchOfferCommandResponse>
    {
        public PatchOfferCommand()
        {
        }
    }
}
