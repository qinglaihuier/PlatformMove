using UnityEngine;
using PlayerInput = Input.PlayerInput;

namespace State_Machine_System.Player_States
{
    [CreateAssetMenu(menuName = "Data/State MaChine System/Player/Idle", fileName = "PlayerStateIdle")]
    public class PlayerStateIdle : PlayerState
    {
        [SerializeField] private float deceleration;
        public override void Enter()
        {
            base.Enter();
            
            PlayerInput.Instance.JumpEvent += Jump;
            
            playerController.HorizontallyMove(0);
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (playerController.DirectionX != 0)
            {
                stateMachine.SwitchState(typeof(PlayerStateRun));
            }

            if (playerController.IsFalling)
            {
                stateMachine.SwitchState(typeof(PlayerStateDrop));
            }
          
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
            
            currentVelocityX = Mathf.MoveTowards(currentVelocityX, 0, deceleration * Time.fixedDeltaTime);
            
            playerController.HorizontallyMove(currentVelocityX);
        }

        public override void Exit()
        {
            base.Exit();
            
            PlayerInput.Instance.JumpEvent -= Jump;
        }

        void Jump()
        {
            stateMachine.SwitchState(typeof(PlayerStateJump));
        }
      
    }
}