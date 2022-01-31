using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace State
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Context context = new Context();

            ModifiedState modified = new ModifiedState();
            modified.DoAction(context);

            DeletedState deleted = new DeletedState();
            deleted.DoAction(context);

            Console.WriteLine(context.GetState().ToString());

            Console.ReadLine();
        }
    }

    internal interface IState
    {
        void DoAction(Context context);
    }

    internal class ModifiedState : IState
    {
        public void DoAction(Context context)
        {
            Console.WriteLine("State: Modified");
            context.SetState(this);
        }

        public override string ToString()
        {
            return "modified";
        }
    }

    internal class DeletedState : IState
    {
        public void DoAction(Context context)
        {
            Console.WriteLine("State: Deleted");
            context.SetState(this);
        }

        public override string ToString()
        {
            return "deleted";
        }
    }

    internal class AddedState : IState
    {
        public void DoAction(Context context)
        {
            Console.WriteLine("State: Added");
            context.SetState(this);
        }

        public override string ToString()
        {
            return "added";
        }
    }

    internal class Context
    {
        private IState _state;

        public void SetState(IState state)
        {
            _state = state;
        }

        public IState GetState()
        {
            return _state;
        }
    }
}