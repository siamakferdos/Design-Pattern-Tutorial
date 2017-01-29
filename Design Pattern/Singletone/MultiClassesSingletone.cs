using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Pattern.Singletone
{
    public class SingleFruit
    {
        public string Name;
        protected SingleFruit()
        { }
        protected static SingleFruit Instance;
        public static SingleFruit UniqueInstance => Instance;
    }

    public class SingleApple : SingleFruit
    {

        private SingleApple()
        {
            Name = "Apple";
        }
        public static SingleFruit UniqueInstance => Instance ?? (Instance = new SingleApple());
    }

    public class SingleOrange : SingleFruit
    {
        private SingleOrange()
        {
            Name = "Orange";
        }
        public static SingleFruit UniqueInstance => Instance ?? (Instance = new SingleOrange());
    }
}
