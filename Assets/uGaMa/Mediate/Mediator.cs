using System;
using uGaMa.Command;
using uGaMa.Manager;

namespace uGaMa.Mediate
{
    public class Mediator : uGaMaBehaviour, IMediator
    {
        private readonly BaseGameManager _uManager;

        private readonly DispatchManager _dispatcher;

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

        public DispatchManager Dispatcher { get { return _dispatcher; } }

        public IView GetView() { return _view; }

        public virtual void Init() { }

        public virtual void OnRegister() { }

        public virtual void OnRemove() { }

        internal void SetView(IView view)
        {
            _view = view;
        }

        public void AddListener(object dispatchKey, Action<NotifyParam> callback)
        {
            Dispatcher.AddListener(this, dispatchKey, callback);
        }

        public void RemoveListener(object dispatchKey, Action<NotifyParam> callback)
        {
            Dispatcher.RemoveListener(this, dispatchKey, callback);
        }

        public void RemoveAllListeners()
        {
            Dispatcher.RemoveAllListeners(this);
        }

        public void OnDestroy()
        {
            OnRemove();
        }
    }
}
