using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var personelCar = new PersonelCar { Type = "BMW", Model = "3.2", HirePrice = 2500 };
            SpecialOffer specialOffer = new SpecialOffer(personelCar);

            Console.WriteLine(personelCar.HirePrice);
            Console.WriteLine(specialOffer.HirePrice);

            Console.ReadLine();
        }
    }

    internal abstract class CarBase
    {
        public abstract string Type { get; set; }
        public abstract string Model { get; set; }
        public abstract decimal HirePrice { get; set; }
    }

    internal class PersonelCar : CarBase
    {
        public override string Type { get; set; }
        public override string Model { get; set; }
        public override decimal HirePrice { get; set; }
    }

    internal class CommorcialCar : CarBase
    {
        public override string Type { get; set; }
        public override string Model { get; set; }
        public override decimal HirePrice { get; set; }
    }

    internal abstract class CarDecoratorBase : CarBase
    {
        private CarBase _carBase;

        protected CarDecoratorBase(CarBase carBase)
        {
            _carBase = carBase;
        }
    }

    internal class SpecialOffer : CarDecoratorBase
    {
        private readonly CarBase _carBase;

        public SpecialOffer(CarBase carBase) : base(carBase)
        {
            _carBase = carBase;
        }

        public override string Type { get; set; }
        public override string Model { get; set; }
        public override decimal HirePrice { get { return _carBase.HirePrice * 90 / 100; } set { } }
    }
}