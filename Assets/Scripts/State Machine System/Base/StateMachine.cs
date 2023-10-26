using System;
using System.Collections.Generic;
using UnityEngine;

namespace State_Machine_System.Base
{
    public class StateMachine : MonoBehaviour
    {
        private IState _currentState;

        protected Dictionary<Type, IState> statesDic;

        private void Update()
        {
            _currentState.LogicUpdate();
        }
        private void FixedUpdate()
        {
            _currentState.PhysicsUpdate();
        }

        protected void SwitchOn(Type newStateType)
        {
            _currentState = statesDic[newStateType];
            
            _currentState.Enter();
        }

        public void SwitchState(Type newStateType)
        {
            _currentState.Exit();
            
            SwitchOn(newStateType);
        }
        
    }
}