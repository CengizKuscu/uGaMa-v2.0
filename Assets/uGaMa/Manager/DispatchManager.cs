using System;
using System.Collections.Generic;
using System.Linq;
using uGaMa.Command;

namespace uGaMa.Manager
{
    public class DispatchManager
    {
        public Dictionary<object, Dictionary<Action<NotifyParam>, uGaMaBehaviour>> DispatchList;

        public DispatchManager()
        {
            DispatchList = new Dictionary<object, Dictionary<Action<NotifyParam>, uGaMaBehaviour>>();
        }

        CommandBinder CommandMap
        {
            get
            {
                return BaseGameManager.GetInstance().commandMap;
            }
        }

        public void AddListener(uGaMaBehaviour obj, object dispatchKey, Action<NotifyParam> callback)
        {
            if(!DispatchList.ContainsKey(dispatchKey))
            {
                var actions = new Dictionary<Action<NotifyParam>, uGaMaBehaviour> {{callback, obj}};
                DispatchList.Add(dispatchKey, actions);
            }
            else
            {
                DispatchList[dispatchKey].Add(callback, obj);
            }
        }

        public void RemoveListener(uGaMaBehaviour obj, object dispatchKey, Action<NotifyParam> callback)
        {
            if (!DispatchList.ContainsKey(dispatchKey)) return;
            var actions = DispatchList[dispatchKey];
            for (var i = 0; i < actions.Count; i++)
            {
                if(actions.Keys.ElementAt(i) == callback && actions.Values.ElementAt(i) == obj)
                {
                    actions.Remove(actions.Keys.ElementAt(i));
                }
            }
        }

        public void RemoveAllListeners(uGaMaBehaviour obj)
        {
            foreach (var item in DispatchList)
            {
                var actions = item.Value;
                if (!actions.ContainsValue(obj)) continue;
                for (var i = 0; i < actions.Count; i++)
                {
                    if(actions.Values.ElementAt(i) == obj)
                    {
                        actions.Remove(actions.Keys.ElementAt(i));
                    }
                }
            }
        }
        
        public void Dispatch(object dispatchKey, object dispatchParam, object dispatchMsg)
        {
            var notify = new NotifyParam(dispatchKey, dispatchParam, dispatchMsg);
            CommandMap.ExecuteCommand(notify);
            SendNotifyToObject(notify);
        }

        public void Dispatch(object dispatchKey, object dispatchParam)
        {
            var notify = new NotifyParam(dispatchKey, dispatchParam, null);
            CommandMap.ExecuteCommand(notify);
            SendNotifyToObject(notify);
        }

        public void Dispatch(object dispatchKey)
        {
            var notify = new NotifyParam(dispatchKey, null, null);
            CommandMap.ExecuteCommand(notify);
            SendNotifyToObject(notify);
        }

        private void SendNotifyToObject(NotifyParam notify)
        {
            if (!DispatchList.ContainsKey(notify.Key)) return;
            var actions = DispatchList[notify.Key];

            for (var i = 0; i < actions.Count; i++)
            {
                var tmpBehavior = actions.Values.ElementAt(i);
                tmpBehavior.OnHandlerNotify(notify, actions.Keys.ElementAt(i));
            }
        }
    }
}
