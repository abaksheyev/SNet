using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SNet.Common
{
    public class Singleton<T> where T : class
    {
        static volatile T _instance;
        static object _lock = new object();

        static Singleton()
        {
        }

        public static T Instance
        {
            get
            {
                if (_instance == null)
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            ConstructorInfo constructor = null;

                            try
                            {
                                // Binding flags exclude public constructors.
                                constructor = typeof(T).GetConstructor(BindingFlags.Instance |
                                              BindingFlags.NonPublic, null, new Type[0], null);
                            }
                            catch (Exception exception)
                            {
                                throw new SingletonException(exception);
                            }

                            if (constructor == null || constructor.IsAssembly)
                                // Also exclude internal constructors.
                                throw new SingletonException(string.Format("A private or " + "protected constructor is missing for '{0}'.", typeof(T).Name));

                            _instance = (T)constructor.Invoke(null);
                        }
                    }

                return _instance;
            }
        }
    }
    

    [Serializable]
    public class SingletonException : Exception
    {
        public SingletonException()
            : base() { }

        public SingletonException(Exception exception)
            : base(exception.Message, exception) { }

        public SingletonException(string message)
            : base(message) { }

        public SingletonException(string format, params object[] args)
            : base(string.Format(format, args)) { }

        public SingletonException(string message, Exception innerException)
            : base(message, innerException) { }

        public SingletonException(string format, Exception innerException, params object[] args)
            : base(string.Format(format, args), innerException) { }

        protected SingletonException(SerializationInfo info, StreamingContext context)
            : base(info, context) { }
    }
    
}
