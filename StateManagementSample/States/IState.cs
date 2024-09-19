using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateManagementSample.States
{
    public interface IState
    {
        bool CanNext { get; }

        IState GetNext();
        void Execute();
    }
}
