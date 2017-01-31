using uGaMa.Command;
using uGaMa.Manager;
using uGaMa.Mediate;
using uGaMa.Model;

namespace uGaMa.Context
{
    [ScriptOrder(-10000)]
    public class Context : uGaMaBehaviour, IContext
    {
        
        protected BaseGameManager uManager;

        public Context()
        {
            
        }

        public void Awake()
        {
            uManager = BaseGameManager.Instance;
            BaseGameManager.SetInstance(uManager);

            CommandMap = uManager.commandMap;
            ModelMap = uManager.modelMap;
            MediatorMap = uManager.mediatorMap;
            Dispatcher = uManager.dispatcher;

            Init();
            Bindings();
        }

        public DispatchManager Dispatcher { get; private set; }

        public CommandBinder CommandMap { get; private set; }

        public ModelBinder ModelMap { get; private set; }

        public MediatorBinder MediatorMap { get; private set; }

        public virtual void Init() { }

        public virtual void Bindings() { }

        public void OnDestroy()
        {
            UnBindings();
        }

        public virtual void UnBindings() { }
        
    }
}
