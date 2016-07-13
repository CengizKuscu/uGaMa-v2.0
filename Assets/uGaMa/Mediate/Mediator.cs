using System;
using System.Collections.Generic;
using System.Linq;
using uGaMa.Command;
using uGaMa.Manager;
using UnityEngine;

namespace uGaMa.Mediate
{
    public class Mediator : MonoBehaviour, IMediator
    {
        private Dictionary<object, Dictionary<Enum, Action<NotifyParam>>> listeners;

        private BaseGameManager _uManager;

        private Dispatcher _dispatcher;

        private IView _view;

        public Mediator()
        {
            _uManager = BaseGameManager.GetInstance();
            _dispatcher = _uManager.dispatcher;
        }

        public void Awake()
        {
            listeners = new Dictionary<object, Dictionary<Enum, Action<NotifyParam>>>();
            Init();
        }

        public BaseGameManager uManager { get { return _uManager; } }

        public Dispatcher dispatcher { get { return _dispatcher; } }

        public IView GetView() { return _view; }

        virtual public void Init() { }

        virtual public void OnRegister() { }

        virtual public void OnRemove() { }

        internal void SetView(IView view)
        {
            _view = view;
        }

        public void AddListener(Enum value, Action<NotifyParam> callback)
        {
            object enumObj = Enum.ToObject(value.GetType(), value);

            if (!listeners.ContainsKey(enumObj))
            {
                Dictionary<Enum, Action<NotifyParam>> tmp = new Dictionary<Enum, Action<NotifyParam>>();

                tmp.Add(value, callback);

                listeners[enumObj] = tmp;
            }
            else
            {
                Dictionary<Enum, Action<NotifyParam>> tmp = listeners[enumObj];
                tmp.Add(value, callback);
            }
        }

        public void RemoveListener(Enum value, Action<NotifyParam> callback)
        {
            object enumObj = Enum.ToObject(value.GetType(), value);
            if (listeners.ContainsKey(enumObj))
            {
                Dictionary<Enum, Action<NotifyParam>> tmp = listeners[enumObj];
                tmp.Remove(value);
                listeners.Remove(enumObj);
            }
        }

        public void RemoveAllListeners()
        {
            listeners.Clear();
        }

        internal void OnHandlerNotify(NotifyParam param)
        {
            object enumObj = param.key;

            if (listeners.ContainsKey(enumObj))
            {
                Dictionary<Enum, Action<NotifyParam>> tmp = listeners[enumObj];

                for (int i = 0; i < tmp.Count; i++)
                {
                    Action<NotifyParam> callback = tmp.Values.ElementAt(i);
                    callback(param);
                }
            }
        }        
    }
}
