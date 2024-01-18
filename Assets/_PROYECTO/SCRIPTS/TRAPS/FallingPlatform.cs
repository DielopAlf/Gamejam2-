using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VictorRivero{

	/// <summary>
	/// 
	/// </summary>

	[RequireComponent(typeof(Rigidbody2D))]
	public class FallingPlatform : MonoBehaviour
	{
		#region Static Fields
		#endregion
		#region Const Field
		#endregion
		#region Param Fields
		#endregion
		#region Private Fields
		[Header("Rigidbody2D")]
		[SerializeField] private Rigidbody2D _rb;
		
		[Space(3)]
		[Header("Times")]
		[SerializeField] private float _fallDelay = 1.0f;
		[SerializeField] private float _destroyDelay = 3.5f;
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
			if (_rb is null)
			{
				_rb = GetComponent<Rigidbody2D>();
			}
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
		private void OnCollisionEnter2D(Collision2D collision)
		{
            if (collision.gameObject.CompareTag("Player"))
            {
                Debug.Log("Jugador");
                StartCoroutine(Fall());
            }
        }
		#endregion
		#region Public Methods
		#endregion
		#region IEnumerator
		IEnumerator Fall()
		{
			yield return new WaitForSeconds(_fallDelay);
			_rb.bodyType = RigidbodyType2D.Dynamic;
			Destroy(gameObject, _destroyDelay);
		}
        #endregion
    }
}