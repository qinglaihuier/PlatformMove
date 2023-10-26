using Characters.Player;
using State_Machine_System.Base;
using UnityEngine;

namespace  State_Machine_System.Player_States
{
    public class PlayerState : ScriptableObject, IState
    {
        [SerializeField]private string animationName;

        [SerializeField, Range(0, 1)] private float duration;
        
        private int _animationNameHash;
        
        protected Animator animator;

        private float _animationStartTime;

        protected float Duration => Time.time - _animationStartTime;

        protected bool IsAnimationEnd => (Time.time - _animationStartTime) >= animator.GetCurrentAnimatorStateInfo(0).length;

        protected PlayerStateMachine stateMachine;

        protected PlayerController playerController;

        protected float currentVelocityX = 0;
        public void Initialize(Animator newAnimator, PlayerStateMachine newStateMachine, PlayerController newPlayerController)
        {
            this.animator = newAnimator;

            this.stateMachine = newStateMachine;

            this.playerController = newPlayerController;

            this._animationNameHash = Animator.StringToHash(animationName);
        }
        public virtual void Enter()
        {
            animator.CrossFade(_animationNameHash, duration);

            _animationStartTime = Time.time;
        }
        public virtual void LogicUpdate()
        {
            
        }
        public virtual void PhysicsUpdate()
        {
            
        }
        public virtual void Exit()
        {
            
        }
    }
}

