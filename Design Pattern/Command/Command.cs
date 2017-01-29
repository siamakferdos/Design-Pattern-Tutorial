using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Pattern.Command
{
    class MultiReceiver
    {

        private delegate void Invoker();

        private delegate void InvokerSet(string s);

        private static Invoker Execute, Redo, Undo;
        private static InvokerSet Set;

        class Command
        {
            public Command(Receiver receiver)
            {
                Set = delegate
                {
                    Console.WriteLine("Not implemented- default of Itpro used");
                    receiver.S = "Itpro";
                };
                Execute = receiver.Action;
                Redo = receiver.Action;
                Undo = receiver.Reverse;
            }
        }

        class Command2
        {
            public Command2(Receiver2 receiver2)
            {
                Set = receiver2.SetData;
                Execute = receiver2.DoIt;
                Redo = receiver2.DoIt;
                Undo = () => Console.WriteLine("Not Implemented");
            }
        }
        class Receiver
        {
            private string _build, _oldBuild;
            private string s = "Itpro String ";

            public string S { get { return s; } set { s = value; } }


            public void Action()
            {
                _oldBuild = _build;
                _build += s;
                Console.WriteLine("Receiver is adding " + _build);
            }

            public void Reverse()
            {
                _build = _oldBuild;
                Console.WriteLine("Receiver is reverting to " + _build);
            }
        }

        class Receiver2
        {
            private string _build, _oldBuild;
            private string s = "Itpro String2 ";

            public void SetData(string s)
            {
                this.s = s;
            }

            public void DoIt()
            {
                _oldBuild = _build;
                _build += s;
                Console.WriteLine("Receiver is building " + _build);
            }
        }

        class Client
        {
            public void ClientMain()
            {
                new Command(new Receiver());
                Execute();
                Redo();
                Undo();
                Set("III");
                Execute();
                Console.WriteLine();
                new Command2(new Receiver2());
                Set("Hoses ");
                Execute();
                Set("Castles ");
                Undo();
                Execute();
                Redo();
            }
        }
    }
}
