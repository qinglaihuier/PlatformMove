using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Input
{
    public class PlayerInput : ScriptableObject,InputActions.IGamePlayActions
    {
        // Start is called before the first frame update
        private  InputActions _inputInstance;

        public InputActions InputInstance => _inputInstance;

        public event Action<Vector2> MoveEvent;

        public event Action StopMoveEvent;

        public event Action JumpEvent;

        public event Action StopPressJumpEvent; 

        public static readonly PlayerInput Instance = CreateInstance<PlayerInput>();
        private void Awake()
        {
            _inputInstance = new InputActions();
            
            _inputInstance.GamePlay.Enable();
                        
            _inputInstance.GamePlay.SetCallbacks(this);
            
            Debug.Log("Awake");
        }

        private void OnEnable()
        {
            Debug.Log("OnEnable");
        }

        private void OnDisable()
        {
            Debug.Log(("OnDisable"));
        }

        public void EnableGamePlayMap()
        {
            _inputInstance.GamePlay.Enable();

            Cursor.lockState = CursorLockMode.Locked;
        }

        public void OnMove(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Started)
            {
                MoveEvent?.Invoke(context.ReadValue<Vector2>());
                
                Debug.Log(("Press Move"));
            }
            else if(context.phase == InputActionPhase.Canceled)
            {
                StopMoveEvent?.Invoke();
            }
        }

        public void OnJump(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Started)
            {
                JumpEvent?.Invoke();
            }

            if (context.phase == InputActionPhase.Canceled)
            {
                StopPressJumpEvent?.Invoke();
            }
        }

       
    }
}

