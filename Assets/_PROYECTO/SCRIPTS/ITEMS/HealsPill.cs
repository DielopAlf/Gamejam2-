using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VictorRivero{

	/// <summary>
	/// 
	/// </summary>

	public class HealsPill : MonoBehaviour
	{
		#region Static Fields
		#endregion
		#region Const Field
		#endregion
		#region Param Fields
		#endregion
		#region Private Fields
		[Header("Heals")]
		[SerializeField] private int _heals;
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
		private void OnTriggerEnter2D(Collider2D collision)
		{
			if (collision.CompareTag("Player"))
			{
				HealthManager.Instance.ModifyHealth(_heals);
				Destroy(gameObject);
			}
		}
		#endregion
		#region Public Methods
		#endregion
	}
}