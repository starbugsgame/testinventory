using Newtonsoft.Json;

namespace Assets.Scripts.Networking.Command.Handlers
{
    public class GetItemFromInventoryHandler : ICommandHandler<ICommand>
    {
        public void Execute(ICommand command)
        {
            HttpClient.HttpClient.Post(JsonConvert.SerializeObject(command));
        }

    }
}
