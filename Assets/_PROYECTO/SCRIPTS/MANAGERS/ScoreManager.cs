using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace VictorRivero{

	/// <summary>
	/// 
	/// </summary>

	public class ScoreManager : MonoBehaviour
	{
        #region Static Fields
        private static ScoreManager _instance;
        public static ScoreManager Instance { get { return _instance; } }
        #endregion
        #region Const Field
        #endregion
        #region Param Fields
        #endregion
        #region Private Fields
        [Header("TMPro")]
        [SerializeField] private TextMeshProUGUI _scoreText;
        [Space(3)]
        [Header("Score")]
        [SerializeField] private int m_score;
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
            _scoreText.text = "00000".PadLeft(5, '0');
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

            DontDestroyOnLoad(gameObject);
		}
	    
		// FixedUpdate is called at fixed time intervals
		void FixedUpdate()
		{
			
		}

        // LateUpdate is called after all Update functions have been called
        #endregion
        #region Private Methods
        #endregion
        #region Public Methods
        public void ModifyScore(int amount)
        {
            m_score += amount;
            _scoreText.text = m_score.ToString().PadLeft(5, '0');
        }
        #endregion
    }
}