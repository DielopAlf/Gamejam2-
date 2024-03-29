using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace VictorRivero{

	/// <summary>
	/// 
	/// </summary>

	public class HealthManager : MonoBehaviour
	{
        #region Static Fields
        private static HealthManager _instance;
        public static HealthManager Instance { get { return _instance; } }
        #endregion
        #region Const Field
        #endregion
        #region Param Fields
        #endregion
        #region Private Fields
        [Header("Slider")]
        [SerializeField] private Slider _healthBar;
        [Header("Text")]
        [SerializeField] private TextMeshProUGUI _text;

        [Space(3)]
        [Header("Values")]
        [SerializeField] private int _maxHealth;
        [SerializeField] private int _curHealth;
        [SerializeField] private int _minHealth;

        [Space(3)]
        [Header("Audio")]
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioClip _damageSound;
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
            SetUpHealthBar();
        }

		// Update is called once per frame
		void Update()
		{
            if (_curHealth > _maxHealth)
            {
                _curHealth = _maxHealth;
            }
            else if (_curHealth < _minHealth)
            {
                _curHealth = 0;
                Dead();
            }
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

            DontDestroyOnLoad(this);
		}
	    
		// FixedUpdate is called at fixed time intervals
		void FixedUpdate()
		{
			
		}

        // LateUpdate is called after all Update functions have been called
        #endregion
        #region Private Methods
        private void SetUpHealthBar()
        {
            _curHealth = _maxHealth;

            _text.text = "X" + _curHealth.ToString().PadLeft(2, '0');
        }
        private void Dead()
        {
            GameManager.Instance.GameOver();
        }
        #endregion
        #region Public Methods
        public void ModifyHealth(int amount)
        {
            _curHealth += amount;
            _text.text = "X" + _curHealth.ToString().PadLeft(2, '0');

            if (_curHealth <= 0)
            {
                // La vida lleg� a 0, juego perdido
                GameManager.Instance.GameOver();
            }
            else {
            if (_audioSource != null && _damageSound != null) {
                    _audioSource.PlayOneShot(_damageSound);
                }
                }
        }
        #endregion

    }
}
        
    
