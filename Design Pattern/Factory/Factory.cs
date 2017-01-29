using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Pattern.Factory
{
    //Abstract Classes--------------------------------------------------------------------------
    abstract class Computer
    {

        public abstract int Mhz { get; }

    }//Computer

    abstract class ComputerFactory
    {

        public abstract Computer GetComputer();

    }//ComputerFactory

    //Implementation 1 --------------------------------------------------------------------------


    class ConcreteComputer : Computer
    {

        int _mhz = 500;

        public override int Mhz
        {

            get { return _mhz; }

        }//Mhz

    }//ConcreteComputer

    class ConcreteComputerFactory : ComputerFactory
    {

        public override Computer GetComputer()
        {

            return new ConcreteComputer();

        }//GetComputer

    }//ConcreteComputerFactory

    //Implementation 2 --------------------------------------------------------------------------

    class BrandXComputer : Computer
    {

        int _mhz = 1500;

        public override int Mhz
        {

            get { return _mhz; }

        }//Mhz

    }//BrandXComputer

    class BrandXFactory : ComputerFactory
    {

        public override Computer GetComputer()
        {

            return new BrandXComputer();

        }//GetComputer

    }//BrandXFactory

    //Creator --------------------------------------------------------------------------
    class ComputerAssembler
    {

        public void AssembleComputer(ComputerFactory factory)
        {

            Computer computer = factory.GetComputer();
            Console.WriteLine("assembled a {0} running at {1} MHz",
               computer.GetType().FullName, computer.Mhz);

        }//AssembleComputer

    }//ComputerAssembler

   
}
