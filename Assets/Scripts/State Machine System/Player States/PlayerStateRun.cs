using UnityEngine;
using PlayerInput = Input.PlayerInput;

namespace State_Machine_System.Player_States
{
    [CreateAssetMenu(menuName = "Data/State MaChine System/Player/Run", fileName = "PlayerStateRun")]
    public class PlayerStateRun : PlayerState
    {

        [SerializeField] private float speedSize = 5;

        [SerializeField] private float acceleration = 2;
        public override void Enter()
        {
            base.Enter();
         
    

            PlayerInput.Instance.StopMoveEvent += StopMove;
            
            PlayerInput.Instance.JumpEvent += Jump;
        }

        public override void Exit()
        {
            base.Exit();
         
            
            PlayerInput.Instance.StopMoveEvent -= StopMove;
            
            PlayerInput.Instance.JumpEvent -= Jump;
        }
        public override void LogicUpdate()
        {
            base.LogicUpdate();
            Debug.Log("Run");
            if (playerController.IsFalling)
            {
                stateMachine.SwitchState(typeof(PlayerStateDrop));
            }
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();

            currentVelocityX = Mathf.MoveTowards(currentVelocityX, speedSize, acceleration * Time.fixedDeltaTime);
            
            playerController.HorizontallyMove(currentVelocityX);
        }
        void Jump()
        {
            stateMachine.SwitchState(typeof(PlayerStateJump));
        }
        void StopMove()
        {
            stateMachine.SwitchState(typeof(PlayerStateIdle));
        }
    }
}