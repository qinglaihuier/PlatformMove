using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace State_Machine_System.Base
{
    public interface IState 
    {
        void Enter();

        void LogicUpdate();

        void PhysicsUpdate();

        void Exit();
    }

}
