using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Manager burak = new Manager { Name = "Burak", Salary = 1000 };
            Manager bugra = new Manager { Name = "Buğra", Salary = 900 };

            Worker omer = new Worker { Name = "Ömer", Salary = 800 };
            Worker nermin = new Worker { Name = "Nermin", Salary = 800 };

            burak.Subordinates.Add(bugra);
            bugra.Subordinates.Add(omer);
            bugra.Subordinates.Add(nermin);

            OrganisationalStructure organisationalStructure = new OrganisationalStructure(burak);

            PayrolVisitor payrolVisitor = new PayrolVisitor();
            Payrise payriseVisitor = new Payrise();

            organisationalStructure.Accept(payrolVisitor);
            organisationalStructure.Accept(payriseVisitor);

            Console.ReadLine();
        }
    }

    internal class OrganisationalStructure
    {
        public EmployeeBase Employee;

        public OrganisationalStructure(EmployeeBase firstEmployee)
        {
            Employee = firstEmployee;
        }

        public void Accept(VisitorBase visitor)
        {
            Employee.Accept(visitor);
        }
    }

    internal abstract class EmployeeBase
    {
        public abstract void Accept(VisitorBase visitor);

        public string Name { get; set; }
        public decimal Salary { get; set; }
    }

    internal class Manager : EmployeeBase
    {
        public Manager()
        {
            Subordinates = new List<EmployeeBase>();
        }

        public List<EmployeeBase> Subordinates { get; set; }

        public override void Accept(VisitorBase visitor)
        {
            visitor.Visit(this);

            foreach (var employee in Subordinates)
            {
                employee.Accept(visitor);
            }
        }
    }

    internal class Worker : EmployeeBase
    {
        public override void Accept(VisitorBase visitor)
        {
            visitor.Visit(this);
        }
    }

    internal abstract class VisitorBase
    {
        public abstract void Visit(Worker worker);

        public abstract void Visit(Manager manager);
    }

    internal class PayrolVisitor : VisitorBase
    {
        public override void Visit(Worker worker)
        {
            Console.WriteLine("{0} paid {1}", worker.Name, worker.Salary);
        }

        public override void Visit(Manager manager)
        {
            Console.WriteLine("{0} paid {1}", manager.Name, manager.Salary);
        }
    }

    internal class Payrise : VisitorBase
    {
        public override void Visit(Worker worker)
        {
            Console.WriteLine("{0} salary increased to {1}", worker.Name, worker.Salary * (decimal)1.1);
        }

        public override void Visit(Manager manager)
        {
            Console.WriteLine("{0} salary increased to {1}", manager.Name, manager.Salary * (decimal)1.2);
        }
    }
}