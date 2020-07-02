using BAYSOFT.Core.Domain.Entities.MinecraftTraders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BAYSOFT.Core.Application.MinecraftTraders.Offers.Commands.PutOffer
{
    public class PutOfferCommand : ApplicationRequest<Offer, PutOfferCommandResponse>
    {
        public PutOfferCommand()
        {
        }
    }
}
