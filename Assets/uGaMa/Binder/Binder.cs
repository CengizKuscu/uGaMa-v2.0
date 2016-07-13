using System;
using System.Collections.Generic;
using UnityEngine;

namespace uGaMa.Binder
{
    public class Binder : IBinder
    {
        public Dictionary<object, IBinding> bindings;

        public delegate void BindingResolver(IBinding binding);

        public Binder ()
        {
            bindings = new Dictionary<object, IBinding>();
        }

        virtual public IBinding Bind(object obj)
        {
            IBinding binding = new Binding();
            binding.Bind(obj);
            resolver(binding);
            return binding;
        }

        virtual protected void resolver(IBinding binding)
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
        
        virtual public IBinding Bind<T>() { return Bind(typeof(T)); }

        virtual public IBinding GetBind(object key)
        {
            if(bindings.ContainsKey(key))
            {
                return bindings[key];
            }
            return null;
        }

        virtual public IBinding GetBind<T>()
        {
            return GetBind(typeof(T));
        }

        virtual public void UnBind(object key)
        {
            IBinding binding = GetBind(key);
            if (binding == null)
            {
                return;
            }
            binding.Binded.Clear();
            bindings.Remove(key);
        }

        virtual public void UnBind<T>() { UnBind(typeof(T)); }
    }
}
