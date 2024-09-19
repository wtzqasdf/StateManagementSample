using StateManagementSample.States;
using System.Reflection.Metadata;
using System.Security;

namespace StateManagementSample
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            //Define data object
            UserData userData = new UserData();
            //Define state objects
            InputState inputState = new InputState(userData);
            VerificationState verificationState = new VerificationState(userData);
            LockState lockState = new LockState(userData);
            SessionState sessionState = new SessionState(userData);
            //Set state
            inputState.SetState(verificationState);
            verificationState.SetStates(inputState, sessionState, lockState);
            //Run state
            IState current = inputState;
            while (current != null)
            {
                current.Execute();
                if (current.CanNext)
                {
                    current = current.GetNext();
                }
            }
            Console.WriteLine("Done");
        }
    }
}