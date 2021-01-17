using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Networking.Command.Handlers
{
    public class AddItemToInventoryHandler : ICommandHandler<ICommand>
    {
        public void Execute(ICommand command)
        {
            HttpClient.Post(JsonUtility.ToJson(command));
        }
    }
}
