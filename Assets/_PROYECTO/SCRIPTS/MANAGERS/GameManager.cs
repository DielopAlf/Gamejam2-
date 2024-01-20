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
        [Header("Audio")]
        [SerializeField] private AudioSource backgroundAudioSource;
        [SerializeField] private AudioSource victoryAudioSource;
        [SerializeField] private AudioSource defeatAudioSource;
        [SerializeField] private AudioClip backgroundSound;
        [SerializeField] private AudioClip victorySound;
        [SerializeField] private AudioClip defeatSound;

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
            // Reproducir el sonido principal al inicio del juego
             {
            Application.targetFrameRate = _frameRate;

            if (_finishZone is null) {
                _finishZone = FindAnyObjectByType<FinishZone>();
            }

            // Reproducir sonido principal al inicio
            PlayBackgroundSound();
        }
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
        private void PlayBackgroundSound()
        {
            if (backgroundAudioSource != null && backgroundSound != null)
            {
                backgroundAudioSource.clip = backgroundSound;
                backgroundAudioSource.Play();
            }
        }
        private void StopBackgroundSound()
        {
            if (backgroundAudioSource != null)
            {
                backgroundAudioSource.Stop();
            }
        }
        private void PlayVictorySound()
        {
            if (victoryAudioSource != null && victorySound != null)
            {
                victoryAudioSource.PlayOneShot(victorySound);
            }
        }
        private void PlayDefeatSound()
        {
            if (defeatAudioSource != null && defeatSound != null)
            {
                defeatAudioSource.PlayOneShot(defeatSound);
            }
        }
        #endregion
        #region Public Methods
        public void BackToMainMenu()
        {
            Debug.Log("Volviendo al Menu Principal!");
        }
        public void NextLevel()
        {
            Debug.Log("Siguiente Nivel");
        }
        public void RestartLevel()
        {
            Debug.Log("Reiniciando Nivel");
        }
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
        public void GameOver() 
        {
            Time.timeScale = 0.0f;
            HudManager.Instance.FailGame();

            // Detener sonido principal y reproducir sonido de derrota
            StopBackgroundSound();
            PlayDefeatSound();


        }
        public void GameWon()
        {
            Time.timeScale = 0.0f;
            HudManager.Instance.VictoryScreen();
            HudManager.Instance.BackToMainMenu();

            // Detener sonido principal y reproducir sonido de victoria
            StopBackgroundSound();
            PlayVictorySound();
        }
        #endregion

    }
}