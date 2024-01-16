using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VictorRivero{

	/// <summary>
	/// 
	/// </summary>

	public class EnemyDisplay : MonoBehaviour
	{
		#region Static Fields
		#endregion
		#region Const Field
		#endregion
		#region Param Fields
		#endregion
		#region Private Fields
		[Header("Enemy Base")]
		[SerializeField] private EnemyBase m_EnemyBase;
		#endregion
		#region Public Fields
		public EnemyBase m_Base { get { return m_EnemyBase; } }
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
		#endregion
	}
}