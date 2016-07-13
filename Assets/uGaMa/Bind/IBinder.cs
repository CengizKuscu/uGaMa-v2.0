namespace uGaMa.Bind
{
    public interface IBinder
    {
        IBinding Bind(object key);

        IBinding Bind<T>();

        IBinding GetBind(object key);

        IBinding GetBind<T>();

        void UnBind(object key);

        void UnBind<T>();
    }
}
