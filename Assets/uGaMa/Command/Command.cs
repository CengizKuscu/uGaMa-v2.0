using uGaMa.Manager;

namespace uGaMa.Command
{
    public class Command : ICommand
    {
        private readonly BaseGameManager _uManager;

        private readonly DispatchManager _dispatcher;

        public Command()
        {
            _uManager = BaseGameManager.GetInstance();
            _dispatcher = _uManager.dispatcher;
        }

        public BaseGameManager uManager { get { return _uManager; } }

        public DispatchManager Dispatcher { get { return _dispatcher; } }

        public virtual void Execute(NotifyParam notify) { }
    }
}
