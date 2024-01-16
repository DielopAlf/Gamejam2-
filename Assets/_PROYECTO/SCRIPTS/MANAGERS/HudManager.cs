using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace VictorRivero
{

    /// <summary>
    /// 
    /// </summary>

    public class HudManager : MonoBehaviour
    {
        #region Static Fields
        private static HudManager _instance;
        public static HudManager Instance { get { return _instance; } }
        #endregion
        #region Const Field
        #endregion
        #region Param Fields
        #endregion
        #region Private Fields
        [Header("MainMenu Screen")]
        [SerializeField] private GameObject _mainMenmuGo;
        
        [Space(3)]
        [Header("Pause GO")]
        [SerializeField] private GameObject _pauseGo;
        [Tooltip("Is active?")]
        [SerializeField] private bool _onPause;

        [Space(3)]
        [Header("Pop Ups")]
        [SerializeField]private GameObject _quitPopUpGo;
        [SerializeField]private GameObject _mainMenuPopUp;
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
        public void BackToMainMenu()
        {
            //Cargaremos la escena del menu principal
            // o activaremos el GO del menu principal
            StartCoroutine(PopUpMainMenu());
        }
        public void PauseGame(InputAction.CallbackContext context)
        {
            //ESTE ES OTRO MÉTODO
            
            /*float originalTimeScale = Time.timeScale;

            //Recordar el metodo de LeanTween para que no le afecte el TimeScale
            //SetIgnoreTimeScale(true);

            if (!_onPause)
            {
                _pauseGo.SetActive(true);
                
                Time.timeScale = 0.0f;

                _onPause = !_onPause;
            }else if (_onPause)
            {
                _pauseGo.SetActive(false);

                Time.timeScale = originalTimeScale;

                _onPause = !_onPause;
            }*/
            
            //
            Time.timeScale = 0.0f;
            if (!_onPause)
            {
                StartCoroutine(PanelPause());
                _onPause = !_onPause;
            }
        }
        public void ResumeGame()
        {
            Time.timeScale = 1.0f;
            StartCoroutine(ResumePanelPause());
            _onPause = !_onPause;
        }
        public void RestartGame()
        {
            StartCoroutine(Restart());
        }
        public void SettingsGame()
        {
            StartCoroutine(SettingsPanel());
        }
        public void Reset()
        {
            _pauseGo.SetActive(false);
        }
        public void QuitPopUp()
        {
            StartCoroutine(PopUpQuit());
        }
        public void CancelPopUp()
        {
            _quitPopUpGo.SetActive(false);
            _mainMenuPopUp.SetActive(false);
        }
        #endregion
        #region IEnumerators
        IEnumerator PanelPause()
        {
            _pauseGo.SetActive(true);
            float scale = 0.0f;

            while (scale != 1.0f)
            {
                scale += Time.unscaledDeltaTime;
                scale = Mathf.Clamp01(scale);

                //Animacion del panel de Pausa


                //
                yield return null;
            }
        }
        IEnumerator ResumePanelPause()
        {
            _pauseGo.SetActive(false);
            float scale = 1.0f;

            while (scale != 0.0f)
            {
                scale += Time.deltaTime;
                scale = Mathf.Clamp01(scale);

                //Animacion del panel de Pausa


                //
                yield return null;
            }
        }
        IEnumerator Restart()
        {
            yield return null;
        }
        IEnumerator SettingsPanel()
        {
            yield return null;
        }
        IEnumerator PopUpMainMenu()
        {
            _mainMenuPopUp.SetActive(true);
            yield return null;
        }
        IEnumerator PopUpQuit()
        {
            _quitPopUpGo.SetActive(true);
            yield return null;
        }
        #endregion
    }
}



