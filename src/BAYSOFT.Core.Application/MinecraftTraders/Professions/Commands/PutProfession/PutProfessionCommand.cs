using BAYSOFT.Core.Domain.Entities.MinecraftTraders;

namespace BAYSOFT.Core.Application.MinecraftTraders.Professions.Commands.PutProfession
{
    public class PutProfessionCommand : ApplicationRequest<Profession, PutProfessionCommandResponse>
    {
        public PutProfessionCommand()
        {
            ConfigKeys(x => x.ProfessionID);

            ConfigSuppressedProperties(x => x.Villagers);
            ConfigSuppressedProperties(x => x.ProfessionItems);

            ConfigSuppressedResponseProperties(x => x.Villagers);
            ConfigSuppressedResponseProperties(x => x.ProfessionItems);
        }
    }
}
