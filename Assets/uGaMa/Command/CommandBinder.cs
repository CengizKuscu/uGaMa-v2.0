using System;
using uGaMa.Bind;

namespace uGaMa.Command
{
    public class CommandBinder : Binder
    {
        public CommandBinder() : base()
        {

        }

        protected internal void ExecuteCommand(NotifyParam param)
        {
            var binding = GetBind(param.Key);

            if(binding == null)
            {
                return;
            }

            var binded = binding.Binded;

            foreach (var pair in binded)
            {
                var cmd = pair.Value as Type;
                if (cmd == null) continue;
                var command = (ICommand)Activator.CreateInstance(cmd);
                command.Execute(param);
            }            
        }
    }
}
