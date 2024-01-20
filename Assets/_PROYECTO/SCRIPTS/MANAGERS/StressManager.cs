using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace VictorRivero{

	/// <summary>
	/// 
	/// </summary>

	public class StressManager : MonoBehaviour
	{
        #region Static Fields
        private static StressManager _instance;
        public static StressManager Instance { get { return _instance; } }
        #endregion
        #region Const Field
        #endregion
        #region Param Fields
        #endregion
        #region Private Fields
        [Header("Slider")]
        [SerializeField] private Slider _stressBar;
        [Space(3)]
        [Header("Values")]
        [SerializeField] private float _maxStress = 100.0f;
        [SerializeField] private float _curStress = 0.0f;
        [SerializeField] private float _stressGain;
        [SerializeField] private float _stressLess;
        [Space(3)]
        [Header("Timer")]
        [SerializeField] private float _timer;
        [SerializeField] private float _timerLessHealth;
        [SerializeField] private float _timeToLess;
        [SerializeField] private float _timeStress;
        [SerializeField] private float _timeExplote;
        [SerializeField] private float _timeToExplote;
        #endregion
        #region Public Fields
        #endregion
        #region Lifecycle
        #endregion
        #region Public API
        #endregion
        #region Unity Methods

        [Header("Audio")]
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioClip _stressDamageSound;

        // Start is called before the first frame update
        void Start()
		{
            _stressBar.maxValue = _maxStress;
            _stressBar.value = _curStress;
            _stressBar.minValue = 0.0f;
        }

		// Update is called once per frame
		void Update()
		{
            _timer += Time.deltaTime;
            ;
            if (_timer >= _timeStress)
            {
                Debug.Log("Subiendo estres");
                GainStressByTime();
                _timer = 0.0f;
            }

            _stressBar.value = _curStress;

            if (_curStress >= _maxStress)
            {
                _timerLessHealth += Time.deltaTime;

                if (_timerLessHealth >= _timeToLess)
                {
                    HealthManager.Instance.ModifyHealth(-1);
                    _timerLessHealth = 0.0f;
                }

                _curStress = _maxStress;
            }

            if (_curStress >= (_maxStress/2))
            {
                _timeExplote += Time.deltaTime;

                if (_timeExplote > _timeToExplote)
                {
                    ExplotionPower.Instance.Explote = true;
                    //ExplotionPower.Instance.Explotion();
                    StartCoroutine(ExplotionPower.Instance.ExploteBehaviour());
                    _timeExplote = 0.0f;
                }
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
        private void GainStressByTime()
        {
            _curStress += _stressGain;
        }
        #endregion
        #region Public Methods
        public void GainStress(float amount)
        {
            _curStress += amount;
        }
        public void LessStress(float amount)
        {
            Debug.Log("Reduciendo estres!");
            _curStress -= amount;
             if (_audioSource != null && _stressDamageSound != null) {
                _audioSource.PlayOneShot(_stressDamageSound);
            }
        }

        public void TestAddingStress()
        {
            _curStress += _stressGain;
        }
        #endregion
    }
}



