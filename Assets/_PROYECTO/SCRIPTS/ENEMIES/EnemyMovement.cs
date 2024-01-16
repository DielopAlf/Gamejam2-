using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VictorRivero
{

    /// <summary>
    /// 
    /// </summary>
    [RequireComponent(typeof(Rigidbody2D))]
    public class EnemyMovement : MonoBehaviour
    {
        #region Static Fields

        #endregion
        #region Const Field
        #endregion
        #region Param Fields
        #endregion
        #region Private Fields
        [Header("Components")]
        [SerializeField] private EnemyDisplay m_Display;
        [SerializeField] private Rigidbody2D _rb;

        [Space(3)]
        [Header("Stats")]
        [SerializeField] private string _name;
        [SerializeField] private int _health;
        [SerializeField] private int _damage;

        [Space(3)]
        [Header("States")]
        public EnemyState m_State;

        [Space(3)]
        [Header("Movement")]
        [SerializeField] private float _speed;

        [Space(3)]
        [Header("Jump")]
        [SerializeField] private float _jumpForce;

        [Space(3)]
        [Header("Patrol Waypoints")]
        [SerializeField] private Transform _waypointInit;
        [SerializeField] private Transform _waypointFinal;
        [SerializeField] private bool _initPos, _finalPos;

        [Space(3)]
        [Header("Target")]
        [SerializeField] private Transform _target;
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
            switch (m_State)
            {
                case EnemyState.PATROL:
                    Debug.Log("De Patrulla");
                    PatrolWaypoint();
                    break;
                case EnemyState.CHASING:
                    break;
                case EnemyState.ATTACKING:
                    break;
                case EnemyState.DEAD:
                    break;
                case EnemyState.DEFAULT:
                    break;
                default:
                    break;
            }
        }

        // Awake is called when the script is
        // first loaded or when an object is
        // attached to is instantiated
        void Awake()
        {
            if (m_Display is null)
            {
                m_Display = GetComponent<EnemyDisplay>();
            }

            if (_rb is null)
            {
                _rb = GetComponent<Rigidbody2D>();
            }

            _name = m_Display.m_Base.enemyName;
            _health = m_Display.m_Base.enemyHealth;
            _damage = m_Display.m_Base.enemyDamage;
        }

        // FixedUpdate is called at fixed time intervals
        void FixedUpdate()
        {

        }

        // LateUpdate is called after all Update functions have been called
        #endregion
        #region Private Methods
        public void PatrolWaypoint()
        {
            if (transform.position.x == _waypointInit.position.x && _initPos)
            {
                Debug.Log("Desplazando");
                _rb.velocity = new Vector2((_waypointFinal.position.x - transform.position.x) * _speed, _rb.velocity.y);
                _finalPos = false;
            }else if (transform.position.x == _waypointFinal.position.x && _finalPos)
            {
                _rb.velocity = new Vector2((_waypointInit.position.x - transform.position.x) * _speed, _rb.velocity.y);
                _initPos = false;
            }
        }
        private void Dead()
        {
            Destroy(gameObject, 2.0f);
        }
        #endregion
        #region Public Methods
        public void TakeDamage(int amount)
        {
            _health -= amount;
        }
        #endregion
    }
}

