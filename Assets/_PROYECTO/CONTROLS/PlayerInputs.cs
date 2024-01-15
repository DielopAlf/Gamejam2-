using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace VictorRivero{

	/// <summary>
	/// 
	/// </summary>

	public class PlayerInputs : MonoBehaviour
	{
		#region Static Fields
		#endregion
		#region Const Field
		#endregion
		#region Param Fields
		#endregion
		#region Private Fields
		[Header("Character Inputs Values")]
		public Vector2 move;
		public bool jump;
		public bool dash;
		public bool pause;

		[Space(3)]
		[Header("Movement Settings")]
		public bool analogMovement;

		[Space(3)]
		[Header("Mouse Cursor Settings")]
		public bool cursorLocked = true;
		public bool cursorInputForLock = true;

		#endregion
		#region Public Fields
		#endregion
		#region Lifecycle
		#endregion
		#region Public API
		#endregion
		#region Unity Methods
		// Start is called before the first frame update
		void Start()
		{
			
		}

		// Update is called once per frame
		void Update()
		{
			
		}

		// Awake is called when the script is
		// first loaded or when an object is
		// attached to is instantiated
		void Awake()
		{
			
		}
	    
		// FixedUpdate is called at fixed time intervals
		void FixedUpdate()
		{
			
		}

		// LateUpdate is called after all Update functions have been called
		#endregion
		#region Private Methods
		#endregion
		#region Public Methods
#if ENABLE_INPUT_SYSTEM
		public void OnMove(InputValue value)
		{
			MoveInput(value.Get<Vector2>());
		}
		public void OnJump(InputValue value)
		{
			JumpInput(value.isPressed);
		}
		public void OnDash(InputValue value)
		{
			DashInput(value.isPressed);
		}
        public void OnPause(InputValue value)
        {
            PauseInput(value.isPressed);
        }
#endif
		public void MoveInput(Vector2 newMoveDirection)
		{
			move = newMoveDirection;
		}
        public void JumpInput(bool newJumpState)
        {
            jump = newJumpState;
        }
        public void DashInput(bool newDashState)
        {
            dash = newDashState;
        }
        public void PauseInput(bool newPauseState)
        {
            pause = newPauseState;
        }
        private void OnApplicationFocus(bool hasFocus)
        {
            SetCursorState(cursorLocked);
        }
        private void SetCursorState(bool newState)
        {
            Cursor.lockState = newState ? CursorLockMode.Locked : CursorLockMode.None;
        }

        #endregion
    }
}