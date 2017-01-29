using System;
using System.Collections.Generic;

namespace Design_Pattern.Observer
{
  

    /// <summary>
    /// The 'Subject' abstract class
    /// </summary>
    internal abstract class Subject
    {
        private readonly List<Observer> _observers = new List<Observer>();

        public void Attach(Observer observer)
        {
            _observers.Add(observer);
        }

        public void Detach(Observer observer)
        {
            _observers.Remove(observer);
        }

        public void Notify()
        {
            foreach (var o in _observers)
            {
                o.Update();
            }
        }
    }

    /// <summary>
    /// The 'ConcreteSubject' class
    /// </summary>
    internal class ConcreteSubject : Subject
    {
        // Gets or sets subject state
        public string SubjectState { get; set; }
    }

    /// <summary>
    /// The 'Observer' abstract class
    /// </summary>
    internal abstract class Observer
    {
        public abstract void Update();
    }

    /// <summary>
    /// The 'ConcreteObserver' class
    /// </summary>
    class ConcreteObserver : Observer
    {
        private readonly string _name;
        private string _observerState;

        // Constructor
        public ConcreteObserver(
          ConcreteSubject subject, string name)
        {
            Subject = subject;
            _name = name;
        }

        public override void Update()
        {
            _observerState = Subject.SubjectState;
            Console.WriteLine($"Observer {_name}'s new state is {_observerState}");
        }

        // Gets or sets subject
        public ConcreteSubject Subject { get; set; }
    }
}