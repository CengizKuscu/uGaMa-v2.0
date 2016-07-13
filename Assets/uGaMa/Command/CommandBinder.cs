using System;
using System.Collections.Generic;
using uGaMa.Bind;

namespace uGaMa.Command
{
    public class CommandBinder : Binder
    {
        public CommandBinder() : base()
        {

        }

        public override IBinding Bind(object obj) { return base.Bind(obj); }

        public override IBinding Bind<T>() { return base.Bind<T>(); }

        public override IBinding GetBind<T>() { return base.GetBind<T>(); }

        public override IBinding GetBind(object key) { return base.GetBind(key); }

        protected internal void ExecuteCommand(NotifyParam param)
        {
            IBinding binding = GetBind(param.key);

            if(binding == null)
            {
                return;
            }

            Dictionary<object, object> binded = binding.Binded;            

            foreach (KeyValuePair<object, object> pair in binded)
            {
                Type cmd = pair.Value as Type;
                ICommand command = (ICommand)Activator.CreateInstance(cmd);
                command.Execute(param);
            }            
        }
    }
}
