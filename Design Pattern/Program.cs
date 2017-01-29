using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Design_Pattern.Adapter;
using Design_Pattern.Command;
using Design_Pattern.Factory;
using Design_Pattern.Observer;
using Design_Pattern.Proxy;
using Design_Pattern.State;
using Context = Design_Pattern.Strategy.Context;

namespace Design_Pattern
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] exitProgram = { "quit", "exit" };
            var pattern = "";
            do
            {
                Console.WriteLine("Choose one of these design patterns:");
                Console.WriteLine("1-singletone");
                Console.WriteLine("2-adapter");
                Console.WriteLine("3-observer");
                Console.WriteLine("4-iterator");
                Console.WriteLine("5-command");
                Console.WriteLine("6-strategy");
                Console.WriteLine("7-factory");
                Console.WriteLine("8-state");
                Console.WriteLine("9-proxy");
                Console.WriteLine("10-decorator");
                Console.WriteLine("11-facade");

                pattern = Console.ReadLine();
                if (!string.IsNullOrEmpty(pattern))
                {

                    switch (pattern)
                    {
                        case "1":
                        case "singletone":

                            break;
                        case "2":
                        case "adapter":
                            ITarget aa = new Adapter.Adapter();
                            Console.WriteLine(aa.Request(5));
                            Console.WriteLine(((Adaptee)aa).SpecificRequest(8, 3));
                            break;
                        case "3":
                        case "observer":

                            ConcreteSubject s = new ConcreteSubject();

                            s.Attach(new ConcreteObserver(s, "X"));
                            s.Attach(new ConcreteObserver(s, "Y"));
                            s.Attach(new ConcreteObserver(s, "Z"));

                            // Change subject and notify observers
                            s.SubjectState = "ABC";
                            s.Notify();
                            break;
                        case "4":
                        case "iterator":
                            var collection = new Iterator.Iterator.MonthCollection();
                            foreach (var element in collection)
                            {
                                Console.WriteLine(element);
                            }
                            break;
                        case "5":
                        case "command":
                            //new MultiReceiver()  Client().ClientMain();
                            break;
                        case "6":
                        case "strategy":
                            Context context = new Context();
                            context.SwitchStrategy();
                            Random r = new Random(37);
                            for (int i = Context.start; i <= Context.start + 15; i++)
                            {
                                if (r.Next(3) == 2)
                                {
                                    Console.Write("|| ");
                                    context.SwitchStrategy();
                                }
                                Console.Write(context.Algorithm() + " ");
                            }
                            Console.WriteLine();
                            break;
                        case "7":
                        case "factory":
                            ComputerFactory factory = null;

                            Console.WriteLine("BrandXFactory : ");
                            factory = new BrandXFactory();
                            new ComputerAssembler().AssembleComputer(factory);

                            Console.WriteLine("ConcreteComputerFactory : ");
                            factory = new ConcreteComputerFactory();
                            new ComputerAssembler().AssembleComputer(factory);

                            break;
                        case "8":
                        case "state":
                            var sc = new State.Context();
                            sc.State = new NormalState();
                            r = new Random(37);
                            for (int i = 5; i <= 25; i++)
                            {
                                int command = r.Next(3);
                                Console.Write(sc.Request(command) + " ");
                            }
                            Console.WriteLine();
                            break;

                        case "9":
                        case "proxy":
                            MathProxy proxy = new MathProxy();

                            // Do the math
                            Console.WriteLine("4 + 2 = " + proxy.Add(4, 2));
                            Console.WriteLine("4 - 2 = " + proxy.Sub(4, 2));
                            Console.WriteLine("4 * 2 = " + proxy.Mul(4, 2));
                            Console.WriteLine("4 / 2 = " + proxy.Div(4, 2));

                            // Wait for user
                            Console.ReadKey();
                            break;

                        case "10":
                        case "decorator":
                            Book book = new Book("Worley", "Inside ASP.NET", 10);
                            book.Display();

                            // Create video
                            Video video = new Video("Spielberg", "Jaws", 23, 92);
                            video.Display();

                            // Make video borrowable, then borrow and display
                            Console.WriteLine("\nMaking video borrowable:");

                            Borrowable borrowvideo = new Borrowable(video);
                            borrowvideo.BorrowItem("Customer #1");
                            borrowvideo.BorrowItem("Customer #2");

                            borrowvideo.Display();

                            // Wait for user
                            Console.ReadKey();
                            break;
                        case "11":
                        case "facade":
                            Facade.Facade facade = new Facade.Facade();

                            facade.MethodA();
                            facade.MethodB();

                            // Wait for user
                            Console.ReadKey();
                            break;
                        default:
                            Console.WriteLine("Bye?");
                            break;


                    }
                }
                Console.ReadKey();
                Console.Clear();
            } while (!exitProgram.Contains(pattern.ToLower()));
        }
    }
}
