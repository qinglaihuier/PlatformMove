using UnityEngine;
using PlayerInput = Input.PlayerInput;

namespace Characters.Player
{
    public class PlayerController : MonoBehaviour
    {
        private Rigidbody _rigidbody;

        private Vector2 _moveDirection;

        public float DirectionX => _moveDirection.x;
        
        private PlayerGroundedDetector _groundedDetector;

        public bool IsGround => _groundedDetector.IsGround;

        public bool isJump;

        public bool IsFalling => _rigidbody.velocity.y < 0 && !IsGround;
        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();

            _groundedDetector = GetComponentInChildren<PlayerGroundedDetector>();
        }

        private void OnEnable()
        {
            PlayerInput.Instance.MoveEvent += Move;

            PlayerInput.Instance.StopMoveEvent += StopMove;

            PlayerInput.Instance.JumpEvent += Jump;

            PlayerInput.Instance.StopPressJumpEvent += StopPressJump;
        }

        private void OnDisable()
        {
            PlayerInput.Instance.MoveEvent -= Move;
            
            PlayerInput.Instance.StopMoveEvent -= StopMove;
            
            PlayerInput.Instance.JumpEvent -= Jump;

            PlayerInput.Instance.StopPressJumpEvent -= StopPressJump;

        }

        public void HorizontallyMove(float velocityXSize)
        {
            Vector3 scale = transform.localScale;

            if (_moveDirection.x != 0)
            {
                transform.localScale = new Vector3(_moveDirection.x, scale.y, scale.z);
            }
            
            SetVelocityX(_moveDirection.x * velocityXSize);
        }

        public void SetVelocity(Vector3 direction, float velocitySize)
        {
            _rigidbody.velocity = direction.normalized * velocitySize;
        }

        public void SetVelocityX(float velocityX)
        {
            Vector3 v = _rigidbody.velocity;

            _rigidbody.velocity = new Vector3(velocityX, v.y, v.z);
        }

        public void SetVelocityY(float velocityY)
        {
            Vector3 v = _rigidbody.velocity;

            _rigidbody.velocity = new Vector3(v.x, velocityY, v.z);
        }

        void Move(Vector2 input)
        {
            _moveDirection = input;
        }

        void Jump()
        {
            isJump = true;
        }

        void StopMove()
        {
            _moveDirection.x = 0;
        }

        void StopPressJump()
        {
            isJump = false;
        }
    }
}

