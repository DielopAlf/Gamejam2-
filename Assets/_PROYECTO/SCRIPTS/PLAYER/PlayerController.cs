using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
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
        [SerializeField] private Animator _anim;

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
		[SerializeField] private bool _isWalking = false;

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
			if (_inputs is null)
			{
				_inputs = GetComponent<PlayerInputs>();
			}
			if (_rb is null)
			{
				_rb = GetComponent<Rigidbody2D>();
			}
			if (_anim is null)
			{
				_anim = GetComponentInChildren<Animator>();
			}
		}

		// Update is called once per frame
		void Update()
		{
			if (_isDashing)
			{
				return;
			}

            //_anim.SetBool("Horizontal", Mathf.Abs(horizontal) > 0.1f);
            //_anim.SetBool("en suelo", !IsGrounded());
            

            //Desplazamos al personaje
            _rb.velocity = new Vector2(horizontal * _speed, _rb.velocity.y);

			//Volteamos al personaje
			if (!_isFacingRight && horizontal > 0.0f)
			{
				Flip();
				Debug.Log("Derecha");
			}else if(_isFacingRight && horizontal < 0.0f)
			{
                Flip();
                Debug.Log("Izquierda");
            }

			if (horizontal == 0)
			{
				_isWalking = false;
                _anim.SetInteger("Horizontal", 0);
            }

			//Animaciones
            _anim.SetInteger("Horizontal", (int)horizontal);
            _anim.SetBool("Walk", _isWalking);
            _anim.SetBool("Jump", !IsGrounded());

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
            
			_isWalking = true;
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