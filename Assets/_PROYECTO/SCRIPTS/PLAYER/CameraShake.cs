using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VictorRivero{

	/// <summary>
	/// 
	/// </summary>

	public class CameraShake : MonoBehaviour
	{
		#region Static Fields
		private static CameraShake _instance;
		public static CameraShake Instance { get { return _instance; } }
		#endregion
		#region Const Field
		#endregion
		#region Param Fields
		#endregion
		#region Private Fields
		private float _smoothShake = 0.0125f;
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
			if (_instance is null)
			{
				_instance = this;
			}

			DontDestroyOnLoad(_instance);
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
        #region IEnumerator
		public IEnumerator Shake(float duration, float magnitude)
		{
			Vector3 originalPos = transform.position;

			float elapsed = 0.0f;

			while (elapsed < duration)
			{
				float x = transform.position.x + Random.Range(-0.3f, 0.3f) * magnitude * _smoothShake;//Random.Range(-1.0f, 1.0f) * magnitude;
                float y = transform.position.y + Random.Range(-0.3f, 0.3f) * magnitude * _smoothShake;//Random.Range(-1.0f, 1.0f) * magnitude;

                transform.localPosition = new Vector3(x, y, originalPos.z);

				elapsed += Time.deltaTime;

				yield return null;
			}

			transform.localPosition = originalPos;
		}
        #endregion
    }
}