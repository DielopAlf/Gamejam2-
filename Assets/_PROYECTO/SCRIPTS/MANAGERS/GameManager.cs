using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace VictorRivero
{

    /// <summary>
    /// 
    /// </summary>

    public class GameManager : MonoBehaviour
    {
        #region Static Fields
        private static GameManager _instance;
        public static GameManager Instance { get { return _instance; } }
        #endregion
        #region Const Field
        #endregion
        #region Param Fields
        #endregion
        #region Private Fields
        [Header("Frame Rate")]
        [SerializeField]private int _frameRate;

        [Space(3)]
        [Header("Finish Zone")]
        [SerializeField] private FinishZone _finishZone;

        [Space(3)]
        [Header("Control")]
        [SerializeField] private bool _victory = false;
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
            Application.targetFrameRate = _frameRate;

            if (_finishZone is null)
            {
                _finishZone = FindAnyObjectByType<FinishZone>();
            }
        }

        // Update is called once per frame
        void Update()
        {
            _victory = _finishZone.IsFinished;

            if (_victory)
            {
                HudManager.Instance.VictoryScreen();
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

        #endregion
        #region Public Methods
        public void ApplicationQuit()
        {            
            HudManager.Instance.QuitPopUp();            
        }
        public void AceptQuit()
        {
            Debug.Log("Bye bye!");
            Application.Quit();
        }
        public void AceptMainMenu()
        {
            Debug.Log("Volviendo al menu principal");
        }
        public void Cancel()
        {
            HudManager.Instance.CancelInvoke();
        }
        #endregion
    }
}