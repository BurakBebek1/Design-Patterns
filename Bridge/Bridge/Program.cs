using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager();
            customerManager.MessageMenagerBase = new EmailSender();
            customerManager.UpdateCustomer();

            Console.ReadLine();
        }
    }

    internal abstract class MessageMenagerBase
    {
        public void Save()
        {
            Console.WriteLine("Message Saved!");
        }

        public abstract void Send(Body body);
    }

    public class Body
    {
        public string Title { get; set; }
        public string Text { get; set; }
    }

    internal class SmsSender : MessageMenagerBase
    {
        public override void Send(Body body)
        {
            Console.WriteLine("{0} was send via SmsSender", body.Title);
        }
    }

    internal class EmailSender : MessageMenagerBase
    {
        public override void Send(Body body)
        {
            Console.WriteLine("{0} was send via EmailSender", body.Title);
        }
    }

    internal class CustomerManager
    {
        public MessageMenagerBase MessageMenagerBase { get; set; }

        public void UpdateCustomer()
        {
            MessageMenagerBase.Send(new Body { Title = "About the course" });
            Console.WriteLine("Customer Updated");
        }
    }
}