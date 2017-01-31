using System.Collections.Generic;
using UnityEngine;

namespace uGaMa.Bind
{
    public class Binder : IBinder
    {
        public Dictionary<object, IBinding> Bindings;

        public delegate void BindingResolver(IBinding binding);

        public Binder ()
        {
            Bindings = new Dictionary<object, IBinding>();
        }

        public virtual IBinding Bind(object obj)
        {
            IBinding binding = new Binding();
            binding.Bind(obj);
            resolver(binding);
            return binding;
        }

        protected virtual void resolver(IBinding binding)
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
        
        public virtual IBinding Bind<T>() { return Bind(typeof(T)); }

        public virtual IBinding GetBind(object key)
        {
            if(Bindings.ContainsKey(key))
            {
                return Bindings[key];
            }
            return null;
        }

        public virtual IBinding GetBind<T>()
        {
            return GetBind(typeof(T));
        }

        public virtual void UnBind(object key)
        {
            var binding = GetBind(key);
            if (binding == null)
            {
                return;
            }
            binding.Binded.Clear();
            Bindings.Remove(key);
        }

        public virtual void UnBind<T>() { UnBind(typeof(T)); }
    }
}
