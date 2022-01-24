using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Employee burak = new Employee();
            burak.Name = "Burak Bebek";

            Employee bugra = new Employee();
            bugra.Name = "Buğra Bebek";

            burak.AddSubordinate(bugra);

            Employee nermin = new Employee();
            nermin.Name = "Nermin Bebek";

            burak.AddSubordinate(nermin);

            Employee omer = new Employee();
            omer.Name = "Ömer Bebek";

            bugra.AddSubordinate(omer);

            foreach (Employee manager in burak)
            {
                Console.WriteLine(manager.Name);
                foreach (Employee employee in manager)
                {
                    Console.WriteLine(employee.Name);
                }
            }

            Console.ReadLine();
        }
    }

    internal interface IPerson
    {
        string Name { get; set; }
    }

    internal class Employee : IPerson, IEnumerable<IPerson>
    {
        private List<IPerson> _subordinates = new List<IPerson>();

        public void AddSubordinate(IPerson person)
        {
            _subordinates.Add(person);
        }

        public void RemoveSubordinate(IPerson person)
        {
            _subordinates.Remove(person);
        }

        public IPerson GetSubordinate(int index)
        {
            return _subordinates[index];
        }

        public string Name { get; set; }

        public IEnumerator<IPerson> GetEnumerator()
        {
            foreach (var subordinate in _subordinates)
            {
                yield return subordinate;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}