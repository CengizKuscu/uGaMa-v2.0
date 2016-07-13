using System.Collections.Generic;
using uGaMa.Command;
using uGaMa.Mediator;

namespace uGaMa.Manager
{
    public class Dispatcher
    {
        CommandBinder commandMap
        {
            get
            {
                return BaseGameManager.GetInstance().commandMap;        
            }
        }
        
        MediatorBinder mediatorMap
        {
            get
            {
                return BaseGameManager.GetInstance().mediatorMap;
            }
        }
        
        public void Dispatch(object key, object param, object msg)
        {
            NotifyParam notify = new NotifyParam(key, param, msg);
            commandMap.ExecuteCommand(notify);
            SendNotifyToMediators(notify);
        }

        public void Dispatch(object key, object param)
        {
            NotifyParam notify = new NotifyParam(key, param, null);
            commandMap.ExecuteCommand(notify);
            SendNotifyToMediators(notify);
        }

        public void Dispatch(object key)
        {
            NotifyParam notify = new NotifyParam(key, null, null);
            commandMap.ExecuteCommand(notify);
            SendNotifyToMediators(notify);
        }

        private void SendNotifyToMediators(NotifyParam notify)
        {
            Dictionary<object, Dictionary<object, IMediator>> mediators = mediatorMap.mediators;

            foreach (KeyValuePair<object, Dictionary<object, IMediator>> pair in mediators)
            {
                Dictionary<object, IMediator> mediated = pair.Value;

                foreach (KeyValuePair<object, IMediator> item in mediated)
                {
                    Mediator.Mediator mediate = item.Value as Mediator.Mediator;
                    mediate.OnHandlerNotify(notify);
                }
            }
        }
    }
}
