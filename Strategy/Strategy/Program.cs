using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager();
            customerManager.CreditCalculatorBase = new After2010CreditCalculator();
            customerManager.SaveCredit();

            customerManager.CreditCalculatorBase = new Before2010CreditCalculator();
            customerManager.SaveCredit();

            Console.ReadLine();
        }
    }

    internal abstract class CreditCalculatorBase
    {
        public abstract void Calculate();
    }

    internal class Before2010CreditCalculator : CreditCalculatorBase
    {
        public override void Calculate()
        {
            Console.WriteLine("Credit calculated using before2010");
        }
    }

    internal class After2010CreditCalculator : CreditCalculatorBase
    {
        public override void Calculate()
        {
            Console.WriteLine("Credit calculated using after2010");
        }
    }

    internal class CustomerManager
    {
        public CreditCalculatorBase CreditCalculatorBase { get; set; }

        public void SaveCredit()
        {
            Console.WriteLine("Customer Manager Business");
            CreditCalculatorBase.Calculate();
        }
    }
}