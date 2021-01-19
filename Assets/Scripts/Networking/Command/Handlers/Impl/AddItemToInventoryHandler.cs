using Newtonsoft.Json;

namespace Assets.Scripts.Networking.Command.Handlers.Impl
{
    public class AddItemToInventoryHandler : ICommandHandler<ICommand>
    {
        public void Execute(ICommand command)
        {
            HttpClient.HttpClient.Post(JsonConvert.SerializeObject(command));
        }
    }
}
