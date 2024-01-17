using System.Collections;
using System.Collections.Generic;
using TMPro;
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
        [SerializeField] private GameObject _pointA;
        [SerializeField] private GameObject _pointB;
        [SerializeField] private Transform _currentPoint;
        [Space(2)]
        [Header("Detect Target")]
        [SerializeField] private float _detectDist;
        [SerializeField] private bool _detectedTarget = false;

        [Space(3)]
        [Header("Target")]
        [SerializeField] private Transform _target;

        [Space(3)]
        [Header("Offset FloatPoint")]
        [SerializeField] private Vector3 _offsetFloatPoint;

        [Space(3)]
        [Header("Control")]
        [SerializeField] private bool _isFacingRight = true;
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
            _currentPoint = _pointB.transform;
        }

        // Update is called once per frame
        void Update()
        {
            switch (m_State)
            {
                case EnemyState.PATROL:
                    PatrolWaypoint();
                    TargetDetected();
                    break;
                case EnemyState.CHASING:
                    Chasing();
                    break;
                case EnemyState.ATTACKING:
                    break;
                case EnemyState.DEAD:
                    Dead();
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
            m_State = EnemyState.PATROL;

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
        private void Flip()
        {
            _isFacingRight = !_isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1.0f;
            transform.localScale = localScale;
        }
        private void PatrolWaypoint()
        {
            Vector2 point = _currentPoint.position - transform.position;
            
            if (_currentPoint == _pointB.transform)
            {
                _rb.velocity = new Vector2(_speed, 0.0f);
            }
            else
            {
                _rb.velocity = new Vector2(-_speed, 0.0f);
            }

            if (Vector2.Distance(transform.position, _currentPoint.position) < 0.5f && _currentPoint == _pointB.transform)
            {
                _currentPoint = _pointA.transform;
                Flip();
            }
            
            if (Vector2.Distance(transform.position, _currentPoint.position) < 0.5f && _currentPoint == _pointA.transform)
            {
                _currentPoint = _pointB.transform;
                Flip();
            }

            Debug.Log("Patrullando");
        }
        private void TargetDetected()
        {
            if (Vector2.Distance(transform.position, _target.position) < _detectDist)
            {
                m_State = EnemyState.CHASING;
                _detectedTarget = true;
            }
            else 

            Debug.Log("Detectado");
        }
        private void Chasing()
        {
            float x = _target.position.x - transform.position.x;
            float y = _target.position.y - transform.position.y;

            _rb.velocity = new Vector2(x * _speed, y);

            if (Vector2.Distance(transform.position, _target.position) > _detectDist)
            {
                m_State = EnemyState.PATROL;
                _detectedTarget = false;
            }

            Debug.Log("Persiguiendo");
        }
        private void Dead()
        {
            // Obtenemos el objeto de la Piscina de Objetos
            GameObject _floatPoint = ObjectPool.Instance.GetPooledObject();
            // Imprimimos el valor que deseamos mostrar
            _floatPoint.GetComponentInChildren<TextMeshProUGUI>().text = "+" + m_Display.m_Base.enemyPoints.ToString();
            // Cambiamos el color del texto para que se asemeje al de los enemigos
            _floatPoint.GetComponentInChildren<TextMeshProUGUI>().color = m_Display.m_Base.enemyColor;

            // Comprobamos si es null
             if (_floatPoint != null)
             {
                // En caso de que no lo sea situaremos el objeto en la posicion deseada
        		_floatPoint.transform.position = transform.position + _offsetFloatPoint;
                // Activaremos el objeto
        		_floatPoint.SetActive(true);
             }

             // Desactivaremos el GameObject del Enemigo
             gameObject.SetActive(false);
            // Modificaremos la puntuacion
             ScoreManager.Instance.ModifyScore(m_Display.m_Base.enemyPoints);
        }
        #endregion
        #region Public Methods
        public void TakeDamage(int amount)
        {
            _health -= amount;

            if (_health <= 0)
            {
                m_State = EnemyState.DEAD;
            }
        }
        #endregion

        private void OnDrawGizmos()
        {
            //Points Gizmos
            Gizmos.DrawWireSphere(_pointA.transform.position, 0.5f);
            Gizmos.DrawWireSphere(_pointB.transform.position, 0.5f);
            Gizmos.DrawLine(_pointA.transform.position, _pointB.transform.position);

            //Area Detect Gizmos
            if (_detectedTarget)
            {
                Gizmos.color = Color.red;
            }
            else
            {
                Gizmos.color = Color.green;
            }
            Gizmos.DrawWireSphere(transform.position, _detectDist);
        }
    }

    
}

