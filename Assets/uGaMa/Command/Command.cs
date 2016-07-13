using uGaMa.Manager;

namespace uGaMa.Command
{
    public class Command : ICommand
    {
        private BaseGameManager _uManager;

        private Dispatcher _dispatcher;

        public Command()
        {
            _uManager = BaseGameManager.GetInstance();
            _dispatcher = _uManager.dispatcher;
        }

        public BaseGameManager uManager { get { return _uManager; } }

        public Dispatcher dispatcher { get { return _dispatcher; } }

        virtual public void Execute(NotifyParam notify) { }
    }
}
