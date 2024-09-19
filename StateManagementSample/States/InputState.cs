using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateManagementSample.States
{
    public class InputState : IState
    {
        public bool CanNext { get; private set; }

        private UserData _userData;
        private IState _nextState;

        public InputState(
            UserData userData)
        {
            _userData = userData;
            CanNext = false;
        }

        public void SetState(IState nextState)
        {
            _nextState = nextState;
        }

        public IState GetNext()
        {
            return _nextState;
        }

        public void Execute()
        {
            Console.WriteLine("Enter your username:");
            string userName = Console.ReadLine();
            Console.WriteLine("Enter your password:");
            string password = Console.ReadLine();
            _userData.UserName = userName;
            _userData.Password = password;
            CanNext = true;
        }
    }
}
