﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager();
            productManager.Attach(new CustomerObserver());
            productManager.Attach(new EmployeeObserver());
            productManager.UpdatePrice();

            Console.ReadLine();
        }
    }

    internal class ProductManager
    {
        private List<Observer> _observers = new List<Observer>();

        public void UpdatePrice()
        {
            Console.WriteLine("Product price chanced");
            Notify();
        }

        public void Attach(Observer observer)
        {
            _observers.Add(observer);
        }

        public void Detach(Observer observer)
        {
            _observers.Remove(observer);
        }

        private void Notify()
        {
            foreach (var observer in _observers)
            {
                observer.Update();
            }
        }
    }

    internal abstract class Observer
    {
        public abstract void Update();
    }

    internal class CustomerObserver : Observer
    {
        public override void Update()
        {
            Console.WriteLine("Message to customer");
        }
    }

    internal class EmployeeObserver : Observer
    {
        public override void Update()
        {
            Console.WriteLine("Message to employee");
        }
    }
}