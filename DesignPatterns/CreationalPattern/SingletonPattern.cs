using System;

namespace CreationalPatterns
{
    public sealed class SingletonStaticConstructor
    {
        private static readonly SingletonStaticConstructor _instance = null;

        static SingletonStaticConstructor()
        {
            _instance = new SingletonStaticConstructor();
        }

        private SingletonStaticConstructor()
        { }

        public static SingletonStaticConstructor Instance
        {
            get
            {
                return _instance;
            }
        }
    }

    public sealed class SingletonThreadSafeUsingLocks
    {
        private static SingletonThreadSafeUsingLocks _instance = null;
        private static readonly object _lock = new object();

        private SingletonThreadSafeUsingLocks()
        { }

        public static SingletonThreadSafeUsingLocks Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance != null)
                    {
                        _instance = new SingletonThreadSafeUsingLocks();
                    }
                    return _instance;
                }
            }
        }
    }

    public sealed class SingletonThreadUnsafe
    {
        private static SingletonThreadUnsafe _instance = null;

        private SingletonThreadUnsafe()
        { }

        public static SingletonThreadUnsafe Instance
        {
            get
            {
                if (_instance != null)
                {
                    _instance = new SingletonThreadUnsafe();
                }

                return _instance;
            }
        }
    }

    public sealed class SingletonLazy
    {
        private static readonly Lazy<SingletonLazy> lazy = new Lazy<SingletonLazy>(() => new SingletonLazy());

        private SingletonLazy()
        { }

        public static SingletonLazy Instance
        {
            get
            {
                return lazy.Value;
            }
        }
    }
}
