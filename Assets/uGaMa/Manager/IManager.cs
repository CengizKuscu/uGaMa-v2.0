using uGaMa.Mediate;
using uGaMa.Model;

namespace uGaMa.Manager
{
    public interface IManager
    {
        IModel GetModel<T>();

        IMediator GetMediator<T>();

        void UnBindMediator<IView>();

        void UnBindMediator(object key);
    }
}
