using uGaMa.Command;
using uGaMa.Manager;
using uGaMa.Mediate;
using uGaMa.Model;
using UnityEngine;

namespace uGaMa.Context
{
    [ScriptOrder(-995)]
    public class Context : MonoBehaviour, IContext
    {
        
        protected BaseGameManager uManager;
        
        private CommandBinder _commandMap;
        
        private ModelBinder _modelMap;
        
        private MediatorBinder _mediatorMap;

        private Dispatcher _dispatcher;

        public Context()
        {
            
        }

        public void Awake()
        {
            uManager = BaseGameManager.Instance;
            BaseGameManager.SetInstance(uManager);

            _commandMap = uManager.commandMap;
            _modelMap = uManager.modelMap;
            _mediatorMap = uManager.mediatorMap;
            _dispatcher = uManager.dispatcher;

            Init();
            Bindings();
        }

        public Dispatcher dispatcher { get { return _dispatcher; } }

        public CommandBinder commandMap { get { return _commandMap; } }

        public ModelBinder modelMap { get { return _modelMap; } }

        public MediatorBinder mediatorMap { get { return _mediatorMap; } }

        virtual public void Init() { }

        virtual public void Bindings() { }

        public void OnDestroy()
        {
            UnBindings();
        }

        virtual public void UnBindings() { }
        
    }
}
