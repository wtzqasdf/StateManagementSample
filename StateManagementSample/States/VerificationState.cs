using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateManagementSample.States
{
    public class VerificationState : IState
    {
        public bool CanNext { get; private set; }
        private IState _backState, _nextState, _lockState;
        private IState _moveTo;
        private UserData _userData;
        private int _errorIndex;

        public VerificationState(
            UserData userData)
        {
            _userData = userData;
            CanNext = false;
            _errorIndex = 0;
        }

        public void SetStates(IState backState, IState nextState, IState lockState)
        {
            _backState = backState;
            _nextState = nextState;
            _lockState = lockState;
        }

        public IState GetNext()
        {
            return _moveTo;
        }

        public void Execute()
        {
            CanNext = true;
            if (IsCorrect(out string error) == false)
            {
                Console.WriteLine(error);
                _errorIndex++;
                if (_errorIndex >= 3)
                {
                    _moveTo = _lockState;
                }
                else
                {
                    _moveTo = _backState;
                }
                return;
            }
            _moveTo = _nextState;
        }

        private bool IsCorrect(out string error)
        {
            if (_userData.UserName.Length < 6)
            {
                error = "UserName length less than 6";
                return false;
            }
            if (_userData.Password.Length < 6)
            {
                error = "Password length less than 6";
                return false;
            }
            error = "";
            return true;
        }
    }
}
