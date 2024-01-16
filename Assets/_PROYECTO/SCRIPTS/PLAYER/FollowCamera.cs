using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VictorRivero{

	/// <summary>
	/// 
	/// </summary>

	public class FollowCamera : MonoBehaviour
	{
		#region Static Fields
		#endregion
		#region Const Field
		#endregion
		#region Param Fields
		#endregion
		#region Private Fields
		[Header("Rotation")]
		private Quaternion _defaultRot;

		[Space(3)]
		[Header("Offset")]
		private Vector3 _offset = new Vector3(0.0f, 0.0f, -10.0f); 

		[Space(3)]
		[Header("Target")]
		[SerializeField] private Transform _target;

		[Space(3)]
		[Header("Speed")]
		[Tooltip("Velocidad suavizada de desplazamiento de la MainCamera")]
		private float _smoothSpeed = 0.125f;
        private Vector3 _velocity = Vector3.zero;
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
			transform.rotation = _defaultRot;
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
            Vector3 desiredPosition = _target.position + _offset;
            Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, desiredPosition,ref _velocity, _smoothSpeed);

            transform.position = smoothedPosition;
			
        }

		// LateUpdate is called after all Update functions have been called
		void LateUpdate()
		{
			
		}
		#endregion
		#region Private Methods
		#endregion
		#region Public Methods
		#endregion
	}
}