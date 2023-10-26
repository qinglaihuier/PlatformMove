using System.Collections;
using System.Collections.Generic;
using State_Machine_System.Player_States;
using UnityEngine;

namespace State_Machine_System.Player_States
{
    [CreateAssetMenu(menuName = "Data/State MaChine System/Player/Drop", fileName = "PlayerStateDrop")]
    public class PlayerStateDrop : PlayerState
    {
        // Start is called before the first frame update
        [SerializeField] private AnimationCurve speedCurve;
        
        [SerializeField] private float runSpeed = 5;
        public override void Enter()
        {
            base.Enter();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
            
            playerController.SetVelocityY(speedCurve.Evaluate(Duration));
            
            playerController.HorizontallyMove(runSpeed);

            if (playerController.IsGround)
            {
                stateMachine.SwitchState(typeof(PlayerStateLand));
            }
        }

        public override void Exit()
        {
            base.Exit();
        }
    }

}
