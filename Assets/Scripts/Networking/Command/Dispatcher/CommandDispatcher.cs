using Assets.Scripts.DI;
using System;

namespace Assets.Scripts.Networking.Command.Dispatcher
{
    public class CommandDispatcher : ICommandDispatcher
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
