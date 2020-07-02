using BAYSOFT.Core.Domain.Entities.MinecraftTraders;

namespace BAYSOFT.Core.Application.MinecraftTraders.Professions.Commands.PatchProfession
{
    public class PatchProfessionCommand : ApplicationRequest<Profession, PatchProfessionCommandResponse>
    {
        public PatchProfessionCommand()
        {
            ConfigKeys(x => x.ProfessionID);

            ConfigSuppressedProperties(x => x.Villagers);
            ConfigSuppressedProperties(x => x.ProfessionItems);

            ConfigSuppressedResponseProperties(x => x.Villagers);
            ConfigSuppressedResponseProperties(x => x.ProfessionItems);
        }
    }
}
