using Input;
using UnityEngine;

namespace State_Machine_System.Player_States
{
    [CreateAssetMenu(menuName = "Data/State MaChine System/Player/Land", fileName = "PlayerStateLand")]
    public class PlayerStateLand : PlayerState
    {
        [SerializeField] private float _stiffTime;
        // Start is called before the first frame update
        public override void Enter()
        {
            base.Enter();
            
            playerController.SetVelocity(Vector3.zero, 0);
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (playerController.IsFalling)
            {
                stateMachine.SwitchState(typeof(PlayerStateDrop));
                return;
            }

            if (playerController.isJump)
            {
                stateMachine.SwitchState(typeof(PlayerStateJump));
                return;
            }

            if (Duration < _stiffTime) return;
            
            if (playerController.DirectionX != 0)
            {
                stateMachine.SwitchState(typeof(PlayerStateRun));

                
            }
            else if (IsAnimationEnd)
            {
                stateMachine.SwitchState(typeof(PlayerStateIdle));
            }
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }

        public override void Exit()
        {
            base.Exit();
            
 
        }

       
       
    }

}
