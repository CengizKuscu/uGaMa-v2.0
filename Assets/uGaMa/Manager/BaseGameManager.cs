using System.Collections.Generic;
using uGaMa.Command;
using uGaMa.Context;
using uGaMa.Mediate;
using uGaMa.Model;
using uGaMa.Utils;
using UnityEngine;

namespace uGaMa.Manager
{

    [ScriptOrder(-1000)]
    public class BaseGameManager : Singleton<BaseGameManager>, IManager
    {

        private static BaseGameManager managerInstance;

        private CommandBinder _commandMap;
        
        private ModelBinder _modelMap;
        
        private MediatorBinder _mediatorMap;

        private DispatchManager _dispatcher;

        public List<IContext> contextList;

        protected BaseGameManager()
        {
            
        }

        public static BaseGameManager GetInstance()
        {
            return managerInstance;
        }

        public static void SetInstance(BaseGameManager manager)
        {
            managerInstance = manager;
        }

        public void Awake()
        {
            _commandMap = new CommandBinder();
            _modelMap = new ModelBinder();
            _mediatorMap = new MediatorBinder();
            _dispatcher = new DispatchManager();
        }

        public DispatchManager dispatcher { get { return _dispatcher; } }

        internal CommandBinder commandMap { get { return _commandMap; } }

        internal ModelBinder modelMap { get { return _modelMap; } }

        internal MediatorBinder mediatorMap { get { return _mediatorMap; } }

        public IModel GetModel<T>() { return modelMap.GetModel<T>(); }

        public IMediator GetMediator<T>() { return mediatorMap.GetMediator<T>(); }

        public IMediator GetMediator(IView view) { return mediatorMap.GetMediator(view); }

        public void UnBindMediator<IView>() { mediatorMap.UnBind<IView>(); }

        public void UnBindMediator(object key) { mediatorMap.UnBind(key); }

        public T GetOrAddExtension<T>() where T : Component
        {
            T result = MonoBehaviourUtils.GetOrAddComponent<T>(gameObject);

            return result;
        }

        public void RemoveExtansion<T>() where T : Component
        {
            MonoBehaviourUtils.RemoveComponent<T>(gameObject);
        }
    }

}
