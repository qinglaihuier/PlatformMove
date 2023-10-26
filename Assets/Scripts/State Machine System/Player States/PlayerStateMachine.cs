using System;
using System.Collections.Generic;
using Characters.Player;
using State_Machine_System.Base;
using UnityEngine;
namespace State_Machine_System.Player_States
{
    public class PlayerStateMachine : Base.StateMachine
    {
        private Animator _animator;

        [SerializeField] private PlayerState[] states;

        private PlayerController _playerController;
        private void Awake()
        {
            _animator = GetComponentInChildren<Animator>();

            _playerController = GetComponent<PlayerController>();

            statesDic = new Dictionary<Type, IState>(states.Length);
            
            foreach (var state in states)
            {
                state.Initialize(_animator, this, _playerController);
                
                statesDic.Add(state.GetType(), state);
            }
        }

        private void Start()
        {
            SwitchOn(typeof(PlayerStateIdle));
        }
    }
}