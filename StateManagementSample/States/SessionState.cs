using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateManagementSample.States
{
    public class SessionState : IState
    {
        public bool CanNext { get; private set; }
        private UserData _userData;

        public SessionState(UserData userData)
        {
            _userData = userData;
        }

        public void Execute()
        {
            Console.WriteLine($"Welcome, {_userData.UserName}");
            //do something...
            CanNext = true;
        }

        public IState GetNext()
        {
            return null;
        }
    }
}
