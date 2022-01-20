using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    internal class Program
    {
        private static void Main(string[] args)
        {
        }
    }

    internal class CustomerManager
    {
        private static CustomerManager _customerManager;
        private static object _lockObject = new object();

        private CustomerManager()
        {
            var customerManager = CustomerManager.CreateAsSingleton();
            customerManager.Save();
        }

        public static CustomerManager CreateAsSingleton()
        {
            lock (_lockObject)
            {
                if (_customerManager == null)
                {
                    _customerManager = new CustomerManager();
                }
            }

            return _customerManager;
        }

        public void Save()
        {
            Console.WriteLine("Saved!");
        }
    }
}