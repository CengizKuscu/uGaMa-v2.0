using System;
using System.Collections.Generic;
using System.Linq;
using uGaMa.Command;
using uGaMa.Manager;
using UnityEngine;

namespace uGaMa.Mediate
{
    public class Mediator : uGaMaBehaviour, IMediator
    {
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

        public void AddListener(object dispatchKey, Action<NotifyParam> callback)
        {
            dispatcher.AddListener(this, dispatchKey, callback);
        }

        public void RemoveListener(object dispatchKey, Action<NotifyParam> callback)
        {
            dispatcher.RemoveListener(this, dispatchKey, callback);
        }

        public void RemoveAllListeners()
        {
            dispatcher.RemoveAllListeners(this);
        }
    }
}
