using System.Collections.Generic;
using System.Linq;
using uGaMa.Bind;
using UnityEngine;

namespace uGaMa.Mediate
{
    public class MediatorBinder : Binder
    {
        readonly Dictionary<object, Dictionary<object, IMediator>> _mediators;

        public MediatorBinder():base()
        {
            _mediators = new Dictionary<object, Dictionary<object, IMediator>>();
        }

        public Dictionary<object, Dictionary<object, IMediator>> mediators
        {
            get { return _mediators; }
        }

        public override IBinding Bind<T>() { return Bind(typeof(T)); }

        public override IBinding Bind(object obj)
        {
            IBinding binding = new Binding(resolver);
            binding.Bind(obj);
            
            return binding;
        }

        protected override void resolver(IBinding binding)
        {
            if (Bindings.ContainsKey(binding.Key))
            {
                Debug.Log("Key is already registered");
            }
            else
            {
                Bindings[binding.Key] = binding;
            }
        }

        protected internal IMediator GetMediator<T>()
        {
            if (!mediators.ContainsKey(typeof(T))) return null;
            var mediated = mediators[typeof(T)];
            return mediated.Select(item => mediated[item.Key]).FirstOrDefault();
        }

        protected internal IMediator GetMediator(IView view)
        {
            return (from item in mediators from pair in mediators[item.Key] where pair.Key == view select pair.Value).FirstOrDefault();
        }

        public override void UnBind(object key)
        {
            base.UnBind(key);

            if (_mediators.ContainsKey(key) == false)
            {
                return;
            }

            var mediated = _mediators[key];
            if (mediated != null)
            {
                foreach (var item in mediated)
                {
                    var mediate = mediated[item.Key];
                    var view = mediate.GetView() as View;
                    if (view != null) view.RemoveMED(mediate);
                }
                mediated.Clear();
            }            
            _mediators.Remove(key);
        }

        public void RemoveMED(object key, View view)
        {
            if(_mediators.ContainsKey(key) == false)
            {
                return;
            }

            var mediated = _mediators[key];

            if(mediated.ContainsKey(view))
            {
                view.RemoveMED(mediated[view]);
                mediated.Remove(view);
                
            }

            if (mediated.Count > 0) return;
            mediated.Clear();
            UnBind(key);
        }

        public override void UnBind<T>() { UnBind(typeof(T)); }
    }
}
