using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace VictorRivero{

	/// <summary>
	/// 
	/// </summary>

	public class ExplotionPower : MonoBehaviour
	{
		#region Static Fields
		private static ExplotionPower _instance;
		public static ExplotionPower Instance { get { return _instance; } }
		#endregion
		#region Const Field
		#endregion
		#region Param Fields
		#endregion
		#region Private Fields
		[Header("")]
		[SerializeField] private Vector2 _explotionPos;

		[Space(3)]
		[Header("Components")]
		[SerializeField] private Rigidbody2D _rb;

		[Space(3)]
		[Header("Times")]
		[SerializeField] private float _timeNextExplotion;

		[Space(3)]
		[Header("Control")]
		[SerializeField] private bool _explote;

		[Space(3)]
		[Header("Support")]
		[SerializeField] private float _power;
		#endregion
		#region Public Fields
		public delegate void RandomMovementEvent();
		public static event RandomMovementEvent OnRandomMovement;
		public bool Explote { get { return _explote; } set { _explote = value; } }
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
		}
	    
		// FixedUpdate is called at fixed time intervals
		void FixedUpdate()
		{
			
		}
            
		// LateUpdate is called after all Update functions have been called
		#endregion
		#region Private Methods
		private void MoveRandomDirection()
		{
			if (_explote)
			{
                float x = Random.Range(-5.0f, 5.0f);
                float y = Random.Range(2.0f, 5.0f);

                Vector2 randomDirection = new Vector2(x, y).normalized;
                _rb.velocity = randomDirection * _power;
            }
		}
		private void TriggerRandomMovementEvent()
		{
			OnRandomMovement?.Invoke();
		}
		#endregion            
		#region Public Methods
		public void Explotion()
		{
			if (_explote)
			{
				float x = Random.Range(-5, 5);
				float y = Random.Range(2, 6);

				_explotionPos = new Vector2(x, y);
                _rb.velocity = _explotionPos * _power;
                _explote = false;
			}
		}
		public void TriggerEvent()
		{
			InvokeRepeating("MoveRandomDirection", 0f, _timeNextExplotion);
        }
        #endregion
        #region IEnumerators
		public IEnumerator ExploteBehaviour()
		{
            //MoveRandomDirection();
            float x = Random.Range(-5.0f, 5.0f);
            float y = Random.Range(2.0f, 5.0f);

            Vector2 randomDirection = new Vector2(x, y).normalized;
			_explotionPos = randomDirection * _power;
            _rb.velocity = _explotionPos;
			_explote = false;
            yield return new WaitForSeconds(_timeNextExplotion);
            /*_explote = false;
            yield return null;*/
        }
        #endregion
    }
}