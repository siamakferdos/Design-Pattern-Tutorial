using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Pattern.Strategy
{
    // The Context
    class Context
    {
        // Context state
        public const int start = 5;
        public int Counter = 5;

        // Strategy aggregation
        IStrategy strategy = new Strategy1();

        // Algorithm invokes a strategy method
        public int Algorithm()
        {
            return strategy.Move(this);
        }

        // Changing strategies
        public void SwitchStrategy()
        {
            if (strategy is Strategy1)
                strategy = new Strategy2();
            else
                strategy = new Strategy1();
        }
    }

    // Strategy interface
    interface IStrategy
    {
        int Move(Context c);
    }

    class Strategy1 : IStrategy
    {
        public int Move(Context c)
        {
            return ++c.Counter;
        }
    }

    // Strategy 2
    class Strategy2 : IStrategy
    {
        public int Move(Context c)
        {
            return --c.Counter;
        }
    }

    // Client

}
