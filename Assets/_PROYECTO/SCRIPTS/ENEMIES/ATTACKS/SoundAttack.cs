using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VictorRivero{

	/// <summary>
	/// 
	/// </summary>

	public class SoundAttack : MonoBehaviour
	{
		#region Static Fields
		#endregion
		#region Const Field
		#endregion
		#region Param Fields
		#endregion
		#region Private Fields
		[Header("GameObject")]
		[SerializeField] private GameObject _obj;
		[Space(3)]
		[Header("Collider")]
		[SerializeField]private CircleCollider2D _circleCollider;
		[Space(3)]
		[Header("Scales")]
		[SerializeField] private Vector3 _scaleUp;
		[SerializeField] private Vector3 _scaleDown;
		[Space(3)]
		[Header("Damage")]
		[SerializeField] private int _stressDamage;
		[Space(3)]
		[Header("Times")]
		[SerializeField] private float _timer;
		[SerializeField] private float _timeToEnable;
		[Space(3)]
		[Header("Control")]
		[SerializeField] private bool _hit;
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
			StartCoroutine(ScaledGameObject());
		}

		// Update is called once per frame
		void Update()
		{
			if (_hit)
			{
				_timer += Time.deltaTime;

				if (_timer < _timeToEnable)
				{
					_circleCollider.enabled = false;
				}
				else if (_timer >= _timeToEnable)
				{
					_circleCollider.enabled = true;
					_timer = 0.0f;
					_hit = false;
				}
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
		private IEnumerator ScaledGameObject()
		{
			LeanTween.scale(_obj, _scaleDown * 0.9f, 0.0f);
			LeanTween.scale(_obj, _scaleUp, 3.0f).setLoopPingPong();
			yield return null;
		}
		private void OnTriggerEnter2D(Collider2D collision)
		{
            if (collision.CompareTag("Player"))
            {
                StressManager.Instance.GainStress(_stressDamage);
				StartCoroutine(CameraShake.Instance.Shake(0.125f, 0.1f));
				_hit = true;
            }
        }
		#endregion
		#region Public Methods
		#endregion
	}
}