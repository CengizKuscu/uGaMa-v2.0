using System;
using System.Collections.Generic;
using uGaMa.Bind;
using UnityEngine;

namespace uGaMa.Mediate
{
    public class MediatorBinder : Binder
    {
        Dictionary<object, Dictionary<object, IMediator>> _mediators;

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
            if (bindings.ContainsKey(binding.key))
            {
                Debug.Log("key is already registered");
            }
            else
            {
                bindings[binding.key] = binding;
            }
        }

        protected internal IMediator GetMediator<T>()
        {
            if (mediators.ContainsKey(typeof(T)))
            {
                Dictionary<object, IMediator> mediated = mediators[typeof(T)];
                foreach (KeyValuePair<object, IMediator> item in mediated)
                {
                    return mediated[item.Key];
                }
            }
            return null;
        }

        protected internal IMediator GetMediator(IView view)
        {
            foreach (KeyValuePair<object, Dictionary<object, IMediator>> item in mediators)
            {
                Dictionary<object, IMediator> tmp = mediators[item.Key];
                foreach (KeyValuePair<object, IMediator> pair in tmp)
                {
                    if(pair.Key == view)
                    {
                        return pair.Value;
                    }
                }
            }
            return null;
        }

        public override void UnBind(object key)
        {
            base.UnBind(key);

            if (_mediators.ContainsKey(key) == false)
            {
                return;
            }

            Dictionary<object, IMediator> mediated = _mediators[key];
            if (mediated != null)
            {
                foreach (KeyValuePair<object, IMediator> item in mediated)
                {
                    IMediator mediate = mediated[item.Key];
                    View view = mediate.GetView() as View;
                    view.RemoveMED(mediate);
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

            Dictionary<object, IMediator> mediated = _mediators[key];

            if(mediated.ContainsKey(view))
            {
                view.RemoveMED(mediated[view]);
                mediated.Remove(view);
                
            }

            if(mediated.Count <= 0)
            {
                mediated.Clear();
                UnBind(key);
            }
        }

        public override void UnBind<T>() { UnBind(typeof(T)); }
    }
}
