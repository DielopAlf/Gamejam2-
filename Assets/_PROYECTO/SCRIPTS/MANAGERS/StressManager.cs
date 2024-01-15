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
        [SerializeField] private float _timeStress;
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
        public void LessStressByAction()
        {
            _curStress -= _stressLess;
        }
        public void LessStressPills(float amount)
        {
            _curStress -= amount;
        }
        #endregion
    }
}



