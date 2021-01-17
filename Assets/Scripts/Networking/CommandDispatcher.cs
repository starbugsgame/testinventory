using Assets.Scripts.DI;
using Assets.Scripts.Networking.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Networking
{
    public class CommandDispatcher
    {
        private readonly SimpleDependencyResolver _resolver;

        public CommandDispatcher()
        {
            _resolver = new SimpleDependencyResolver();
        }

        public void Execute<TCommand>(TCommand command) where TCommand : ICommand
        {
            if (command == null) throw new ArgumentNullException("command");

            var handler = _resolver.ResolveHandler(command);

            if (handler == null) throw new Exception(typeof(TCommand).ToString());

            handler.Execute(command);
        }
    }
}
