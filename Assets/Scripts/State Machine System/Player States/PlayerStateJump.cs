using UnityEngine;

namespace State_Machine_System.Player_States
{
    [CreateAssetMenu(menuName = "Data/State MaChine System/Player/Jump", fileName = "PlayerStateJump")]
    public class PlayerStateJump : PlayerState
    {
        [SerializeField] private float jumpSpeed = 10;

        [SerializeField] private float runSpeed = 5;
        // Start is called before the first frame update
        public override void Enter()
        {
            base.Enter();
            
            playerController.SetVelocityY(jumpSpeed);
        }

        public override void LogicUpdate()
        {
            Debug.Log("Jump");
            if (playerController.isJump == false || playerController.IsFalling)
            {
                stateMachine.SwitchState(typeof(PlayerStateDrop));
            }
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
            
            playerController.HorizontallyMove(runSpeed);
        }

        public override void Exit()
        {
            base.Exit();
        }
        
    }
}
