using System;
using uGaMa.Command;

namespace uGaMa.Mediate
{
    public interface IMediator
    {
        void OnRegister();

        void OnRemove();

        IView GetView();

        void AddListener(object dispatchKey, Action<NotifyParam> callback);

        void RemoveListener(object dispatchKey, Action<NotifyParam> callback);

        void RemoveAllListeners();
    }
}
