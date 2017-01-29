using System;

/*
 * Use when there are a class that we don't want manipulate it but we should change something about it.
 * So we make an Interface which contain the methods of our purpose then implement it ina new class.
 * We can use both interface and class as reference to new instance.
 */

namespace Design_Pattern.Adapter
{
    public class Adaptee
    {
        public double SpecificRequest(double a, double b)
        {
            return a / b;
        }
    }

    public interface ITarget
    {
        string Request(int a);
    }




    public class Adapter : Adaptee, ITarget
    {
        public string Request(int a)
        {
            return "the result is" + (int)Math.Round(SpecificRequest(a, 5));
        }
    }
}