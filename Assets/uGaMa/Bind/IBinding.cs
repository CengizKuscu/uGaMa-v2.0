using System.Collections.Generic;

namespace uGaMa.Bind
{
    public interface IBinding
    {
        IBinding Bind(object obj);

        IBinding Bind<T>();

        IBinding To(object obj);

        IBinding To<T>();

        Dictionary<object, object> Binded { get; }

        object key { get; set; }
    }
}
