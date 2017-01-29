using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Pattern.State
{
    interface IState
    {
        int MoveUp(Context context);
        int MoveDown(Context context);
    }

    // State 1
    class NormalState : IState
    {
        public int MoveUp(Context context)
        {
            context.Counter += 2;
            return context.Counter;
        }

        public int MoveDown(Context context)
        {
            if (context.Counter < Context.limit)
            {
                context.State = new FastState();
                Console.Write("|| ");
            }
            context.Counter -= 2;
            return context.Counter;
        }
    }

    // State 2
    class FastState : IState
    {
        public int MoveUp(Context context)
        {
            context.Counter += 5;
            return context.Counter;

        }

        public int MoveDown(Context context)
        {
            if (context.Counter < Context.limit)
            {
                context.State = new NormalState();
                Console.Write("||");
            }
            context.Counter -= 5;
            return context.Counter;
        }
    }

    // Context
    class Context
    {
        public const int limit = 10;
        public IState State { get; set; }
        public int Counter = limit;
        public int Request(int n)
        {
            if (n == 2)
                return State.MoveUp(this);
            else
                return State.MoveDown(this);
        }
    }
}
