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