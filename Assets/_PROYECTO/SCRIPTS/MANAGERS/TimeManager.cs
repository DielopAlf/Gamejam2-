using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace VictorRivero{

	/// <summary>
	/// 
	/// </summary>

	public class TimeManager : MonoBehaviour
	{
        #region Static Fields
        private static TimeManager _instance;
        public static TimeManager Instance { get { return _instance; } }

        #endregion
        #region Const Field
        #endregion
        #region Param Fields
        #endregion
        #region Private Fields
        [Header("Timer Count")]
        [SerializeField]
        private float _timerCount;

        [Space(3)]
        [Header("Timer Text")]
        [SerializeField]
        private TextMeshProUGUI _timerText;
        public string TimerText;

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
            TimerCount();
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
        private void TimerCount()
        {
            //Comenzamos a contar el tiempo
            _timerCount += Time.deltaTime;

            //Dividiremos dicho tiempo en minutos y segundos
            int seconds = (int)(_timerCount % 60);    //Realizamos una operación para comprobar si hemos llegado a contar 60 segundos
            int minutes = (int)(_timerCount / 60) % 60;   //Realizamos una operación para conocer la cantidad de minutos que llebamos

            if (seconds <= 9f)
            {
                _timerText.text = "0" + minutes.ToString() + ":0" + seconds.ToString();
            }
            else if (seconds >= 10f && seconds <= 59.9f)
            {
                _timerText.text = "0" + minutes.ToString() + ":" + seconds.ToString();
                TimerText = _timerText.text;
            }
        }

        #endregion
        #region Public Methods
        #endregion
    }
}