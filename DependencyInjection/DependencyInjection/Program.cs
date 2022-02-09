using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjection
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            IKernel kernel = new StandardKernel();
            kernel.Bind<IProductDal>().To<EFProductDal>().InSingletonScope();

            ProductManager productManager = new ProductManager(kernel.Get<IProductDal>());
            productManager.Save();
            Console.ReadLine();
        }
    }

    internal interface IProductDal
    {
        void Save();
    }

    internal class EFProductDal : IProductDal//Entity Framework
    {
        public void Save()
        {
            Console.WriteLine("Saved with EF");
        }
    }

    internal class NHProductDal : IProductDal//NHibernate
    {
        public void Save()
        {
            Console.WriteLine("Saved with Nh");
        }
    }

    internal class ProductManager
    {
        private IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public void Save()
        {
            _productDal.Save();
        }
    }
}