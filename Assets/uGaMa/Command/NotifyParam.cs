namespace uGaMa.Command
{
    public class NotifyParam
    {
        private object _key;
        private object _data;
        private object _msg;

        public NotifyParam(object key, object data, object msg)
        {
            _key = key;
            _data = data;
            _msg = msg;
        }

        public object key
        {
            get
            {
                return _key;
            }
        }

        public object data
        {
            get
            {
                return _data;
            }
        }

        public object msg
        {
            get
            {
                return _msg;
            }
        }
    }
}
