using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            CreditBase creditManager = new CreditManagerProxy();
            Console.WriteLine(creditManager.Calculate());
            Console.WriteLine(creditManager.Calculate());

            Console.ReadLine();
        }
    }

    internal abstract class CreditBase
    {
        public abstract int Calculate();
    }

    internal class CreditManager : CreditBase
    {
        public override int Calculate()
        {
            int result = 1;
            for (int i = 1; i < 5; i++)
            {
                result *= i;
            }
            return result;
        }
    }

    internal class CreditManagerProxy : CreditBase
    {
        private CreditManager _creditManager;
        private int _cachedValue;

        public override int Calculate()
        {
            if (_creditManager == null)
            {
                _creditManager = new CreditManager();
                _cachedValue = _creditManager.Calculate();
            }

            return _cachedValue;
        }
    }
}