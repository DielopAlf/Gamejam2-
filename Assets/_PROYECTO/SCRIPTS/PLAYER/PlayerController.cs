using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

namespace VictorRivero{

	/// <summary>
	/// 
	/// </summary>

	[RequireComponent(typeof(PlayerInputs))]
	[RequireComponent(typeof(Rigidbody2D))]
	public class PlayerController : MonoBehaviour
	{
		#region Static Fields
		#endregion
		#region Const Field
		#endregion
		#region Param Fields
		#endregion
		#region Private Fields
		[Header("Components")]
		[SerializeField] private PlayerInputs _inputs;
		[SerializeField] private Rigidbody2D _rb;

		[Space(3)]
		[Header("Movement")]
		[SerializeField] private float _speed;
		[SerializeField]private float horizontal;

		[Space(3)]
		[Header("Jump")]
		[SerializeField] private float _jumpForce;
		[SerializeField] private Transform _groundChecker;
		[SerializeField] private float _raycastLength;
		[SerializeField] private LayerMask _groundLayer;
		[Tooltip("Duracion y Magnitud del Shake de Camara")]
		[SerializeField] private float _jumpShakeDuration;
		[SerializeField] private float _jumpShakeMagnitude;

		[Space(3)]
		[Header("Double Jump")]
		[SerializeField] private int _jumpsAmount = 2;
		[SerializeField] private bool _doubleJump = false;

		[Space(3)]
		[Header("Dash")]
		[SerializeField] private bool _canDash = true;
		[SerializeField] private bool _isDashing = false;
		[SerializeField] private float _dashSpeed; //Por defecto sera 10.0f
		[SerializeField] private float _dasingTime;	//Por defecto sera 0.2f
		[SerializeField] private float _dashingCooldown; //Por defecto sera 1.0f
        [Tooltip("Duracion y Magnitud del Shake de Camara")]
        [SerializeField] private float _dashShakeDuration;
        [SerializeField] private float _dashShakeMagnitude;
        [Space(1)]
		[Header("Trail Renderer")]
		[SerializeField] private TrailRenderer _trail;

		[Space(3)]
		[Header("Camera Scripts")]
		[SerializeField] private CameraShake _camShake;

		[Space(5)]
		[Header("Gravity")]
		[SerializeField] private float _gravityForce = -9.5f;

        [Space(3)]
		[Header("Control")]
		[SerializeField] private bool _isFacingRight = true;

		//Comprobamos si toca el suelo
		private bool IsGrounded()
		{
			return Physics2D.OverlapCircle(_groundChecker.position, 0.2f, _groundLayer);
		}
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
			if (_isDashing)
			{
				return;
			}

            //Desplazamos al personaje
            _rb.velocity = new Vector2(horizontal * _speed, _rb.velocity.y);

			//Volteamos al personaje
			if (!_isFacingRight && horizontal > 0.0f)
			{
				Flip();
			}else if(_isFacingRight && horizontal < 0.0f)
			{
                Flip();
            }

            _rb.velocity = new Vector2(_rb.velocity.x, _rb.velocity.y);
        }

		// Awake is called when the script is
		// first loaded or when an object is
		// attached to is instantiated
		void Awake()
		{
			_rb = GetComponent<Rigidbody2D>();
		}
	    
		// FixedUpdate is called at fixed time intervals
		void FixedUpdate()
		{
            if (_isDashing)
            {
                return;
            }

			/*if (!IsGrounded())
			{
                _rb.velocity = new Vector2(_rb.velocity.x, _gravityForce);
            }*/
        }
            
		// LateUpdate is called after all Update functions have been called
		#endregion
		#region Private Methods
		private void Flip()
		{
			_isFacingRight = !_isFacingRight;
			Vector3 localScale = transform.localScale;
			localScale.x *= -1.0f;
			transform.localScale = localScale;
		}
		private IEnumerator DashMovement()
		{
			_canDash = false;
			_isDashing = true;
			float originalGravity = _rb.gravityScale;
			_rb.gravityScale = 0.0f;
			_rb.velocity = new Vector2(transform.localScale.x * _dashSpeed, 0.0f);
			_trail.emitting = true;
			yield return new WaitForSeconds(_dasingTime);
			_trail.emitting = false;
            _rb.gravityScale = originalGravity;	//Al invocar esta corrutina en una funcion no llega a cambiar nuevamente la escala de gravedad a 1.0f
            _isDashing = false;
			yield return new WaitForSeconds(_dashingCooldown);
			_canDash = true;
		}
        #endregion
        #region Public Methods
        public void Move(InputAction.CallbackContext context)
        {
            horizontal = context.ReadValue<Vector2>().x;
        }
        public void Jump(InputAction.CallbackContext context)
		{
			if (context.performed && (IsGrounded() || _doubleJump))
			{
                _rb.velocity = new Vector2(_rb.velocity.x, _jumpForce);
				_doubleJump = !_doubleJump;
            }

			if (context.canceled && _rb.velocity.y > 0.0f)
			{
				_rb.velocity = new Vector2(_rb.velocity.x, _rb.velocity.y * 0.5f);
            }
		}
		public void DobleJump()
		{

		}
		public void Dash(InputAction.CallbackContext context)
		{
			Debug.Log("Dasheando!");
			StartCoroutine(DashMovement()); 
			StartCoroutine(_camShake.Shake(_dashShakeDuration, _dashShakeMagnitude));
            _rb.gravityScale = 1.0f;
        }
		#endregion
	}
}