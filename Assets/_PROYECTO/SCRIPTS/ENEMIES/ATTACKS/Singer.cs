using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VictorRivero{

	/// <summary>
	/// 
	/// </summary>

	public class Singer : MonoBehaviour
	{
		#region Static Fields
		#endregion
		#region Const Field
		#endregion
		#region Param Fields
		#endregion
		#region Private Fields
		[Header("Object Pool")]
		[SerializeField] private ObjectPool _objectPool;

		[Space(3)]
		[Header("Attack")]
		[SerializeField] private float _attackRate;

		[Space(3)]
		[Header("Times")]
        [SerializeField] private float _timer;

        [Space(3)]
		[Header("Control")]
		[SerializeField] private bool _canSing = false;
		
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
			if (!_canSing)
			{
				_timer += Time.deltaTime;
				if (_timer >= _attackRate)
				{
					_canSing = true;
					_timer = 0.0f;
				}
			}

			if (_canSing && _timer == 0.0f)
			{
				Sing();
				_canSing = false;
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
		private void Sing()
		{
			GameObject _singWaveObj = _objectPool.GetPooledObject();

            if(_singWaveObj != null)
            {
            	_singWaveObj.transform.position = transform.position;
            	_singWaveObj.SetActive(true);
            }
        }
        #endregion
        #region Public Methods
        #endregion
        #region IEnumerator
        IEnumerator Singing()
		{
            yield return new WaitForSeconds(_attackRate);
            Sing();
		}
		#endregion
	}
}