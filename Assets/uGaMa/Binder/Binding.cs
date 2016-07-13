using System;
using System.Collections.Generic;

namespace uGaMa.Binder
{
    public class Binding : IBinding
    {
        public Binder.BindingResolver resolver;

        protected Dictionary<object, object> binded;

        protected object _key;

        public Binding():this(null)
        {
            binded = new Dictionary<object, object>();
        }

        public Binding(Binder.BindingResolver resolver)
        {
            this.resolver = resolver;
            binded = new Dictionary<object, object>();
        }

        public Dictionary<object, object> Binded { get { return binded; } }

        public object key {
            get { return _key; }
            set { throw new NotImplementedException(); }
        }

        public IBinding Bind(object obj)
        {
            _key = obj;
            return this;
        }

        public IBinding Bind<T>() { return Bind(typeof(T)); }

        public IBinding To(object obj)
        {
            binded.Add(obj, obj);
            if(resolver != null)
            {
                resolver(this);
            }
            return this;
        }

        public IBinding To<T>() { return To(typeof(T)); }
    }
}
