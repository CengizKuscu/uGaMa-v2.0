using System;
using System.Collections.Generic;
using uGaMa.Bind;

namespace uGaMa.Model
{
    public class ModelBinder : Binder
    {
        Dictionary<object, IModel> models;

        public ModelBinder():base()
        {
            models = new Dictionary<object, IModel>();
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
            if(binding.key != null)
            {
                if (models.ContainsKey(binding.key) == false)
                {
                    Dictionary<object, object> tmp = binding.Binded;
                    foreach (KeyValuePair<object, object> pair in tmp)
                    {
                        Type obj = pair.Value as Type;
                        IModel model = (IModel)Activator.CreateInstance(obj);
                        models.Add(binding.key, model);
                    }
                }
            }            
        }

        protected internal IModel GetModel<T>()
        {
            if(models.ContainsKey(typeof(T)))
            {
                return models[typeof(T)];
            }
            return null;
        }
    }
}
