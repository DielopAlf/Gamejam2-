using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace VictorRivero{

	/// <summary>
	/// 
	/// </summary>

	public class HealsPill : MonoBehaviour
	{
		#region Static Fields
		#endregion
		#region Const Field
		#endregion
		#region Param Fields
		#endregion
		#region Private Fields
		[Header("Heals")]
		[SerializeField] private int _heals;
        
		[Space(3)]
        [Header("Object Pool")]
        [SerializeField] private ObjectPool _objectPool;

        [Space(3)]
        [Header("Offset FloatPoint")]
        [SerializeField] private Vector3 _offsetFloatPoint;
		
		[Space(3)]
        [Header("Audio")]
        [SerializeField] private AudioSource pickupAudioSource;
        [SerializeField] private AudioClip pickupSound;
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
			
		}
	    
		// FixedUpdate is called at fixed time intervals
		void FixedUpdate()
		{
			
		}

		// LateUpdate is called after all Update functions have been called
		#endregion
		#region Private Methods
		private void OnTriggerEnter2D(Collider2D collision)
		{
			if (collision.CompareTag("Player"))
			{
			         PlayPickupSound();
                GameObject _floatPoint = _objectPool.GetPooledObject();
                
				// Imprimimos el valor que deseamos mostrar
                _floatPoint.GetComponentInChildren<TextMeshProUGUI>().text = "+1";

                // Comprobamos si es null
                if (_floatPoint != null)
                {
                    // En caso de que no lo sea situaremos el objeto en la posicion deseada
                    _floatPoint.transform.position = transform.position + _offsetFloatPoint;
                    // Activaremos el objeto
                    _floatPoint.SetActive(true);
                }

                // Desactivaremos el GameObject
                gameObject.SetActive(false);
                // Modificaremos la Salud
                HealthManager.Instance.ModifyHealth(_heals);
				//Destroy(gameObject);
			}

		}
		 private void PlayPickupSound() {
            if (pickupAudioSource != null && pickupSound != null) 
			{
                pickupAudioSource.PlayOneShot(pickupSound);
            }
		#endregion
		#region Public Methods
		#endregion
	}
}
}