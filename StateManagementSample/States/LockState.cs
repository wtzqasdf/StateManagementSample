using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateManagementSample.States
{
    public class LockState : IState
    {
        public bool CanNext { get; private set; }
        private UserData _userData;

        public LockState(UserData userData)
        {
            _userData = userData;
        }

        public void Execute()
        {
            Console.WriteLine("Your account is locked.");
            //do something to lock account...
            CanNext = true;
        }

        public IState GetNext()
        {
            return null;
        }
    }
}
