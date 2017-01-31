using System;
using System.Collections.Generic;
using uGaMa.Bind;

namespace uGaMa.Model
{
    public class ModelBinder : Binder
    {
        readonly Dictionary<object, IModel> _models;

        public ModelBinder():base()
        {
            _models = new Dictionary<object, IModel>();
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
            if (binding.Key == null) return;
            if (_models.ContainsKey(binding.Key) != false) return;
            var tmp = binding.Binded;
            foreach (var pair in tmp)
            {
                var obj = pair.Value as Type;
                if (obj == null) continue;
                var model = (IModel)Activator.CreateInstance(obj);
                _models.Add(binding.Key, model);
            }
        }

        protected internal IModel GetModel<T>()
        {
            return _models.ContainsKey(typeof(T)) ? _models[typeof(T)] : null;
        }
    }
}
