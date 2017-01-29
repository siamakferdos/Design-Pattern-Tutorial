using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Pattern.Singletone
{

    public sealed class SimpleSingleton
    {
        private SimpleSingleton()
        {
        }

        public static SimpleSingleton UniqueInstance { get; } = new SimpleSingleton();
    }

    public class LazySingleton
    {
        private LazySingleton() { }
        private static LazySingleton _instance;

        public static LazySingleton UniqueInstance => _instance ?? new LazySingleton();
    }

    public class SingletonSafeThread
    {
        private SingletonSafeThread() { }

        class SingletonCreator
        {
            static SingletonCreator()
            {
            }
            internal static SingletonSafeThread UniqueInstance { get; } = new SingletonSafeThread();
        }

        public static SingletonSafeThread UniqueInstance => SingletonCreator.UniqueInstance;
    }


}
