using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VictorRivero{

	/// <summary>
	/// 
	/// </summary>

	public class FloatPoints : MonoBehaviour
	{
		#region Static Fields
		#endregion
		#region Const Field
		#endregion
		#region Param Fields
		#endregion
		#region Private Fields
		[SerializeField]private float timeToDeactivate;
        [SerializeField] private float timer;
		//[SerializeField] private GameObject _objectPoolGo;
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
			timer += Time.deltaTime;

			if (timer >= timeToDeactivate)
			{
                //transform.position = transform.parent.transform.position;
                gameObject.SetActive(false);
			}
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