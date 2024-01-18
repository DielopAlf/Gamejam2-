using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VictorRivero{

	/// <summary>
	/// 
	/// </summary>

	public class SingAttack : MonoBehaviour
	{
        #region Static Fields
        #endregion
        #region Const Field
        #endregion
        #region Param Fields
        #endregion
        #region Private Fields
        [Header("Enemy")]
        [SerializeField] private EnemyMovement m_Enemy;
        
        [Space(3)]
        [Header("GameObject")]
        [SerializeField] private GameObject _obj;

        [Space(3)]
        [Header("Original Position")]
        private Vector3 _originalPos;

        [Space(3)]
        [Header("Damage")]
        [SerializeField] private Vector3 _orientation;
        [SerializeField] private int _stressDamage;
        [SerializeField] private float _speed;

        [Space(3)]
        [Header("Times")]
        [SerializeField] private float _timer;
        [SerializeField] private float _timeToDestroy;
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
        void OnEnable()
        {
            if (m_Enemy.IsFacingRight)
            {
                _orientation = Vector3.right;
            }
            else if (!m_Enemy.IsFacingRight)
            {
                _orientation = Vector3.left;
            }

            _timer += Time.deltaTime;
            _originalPos = transform.position;
        }
        // Update is called once per frame
        void Update()
		{
            
            

            transform.Translate(_orientation * _speed * Time.deltaTime);

            _timer += Time.deltaTime;

            if (_timer >= _timeToDestroy)
            {
                transform.position = _originalPos;
                _timer = 0.0f;
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
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                StressManager.Instance.GainStress(_stressDamage);
            }
        }
        #endregion
        #region Public Methods
        #endregion
        #region IEnumerators
        
        #endregion
    }
}