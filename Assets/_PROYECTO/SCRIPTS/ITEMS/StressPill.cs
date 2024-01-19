using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace VictorRivero{

	/// <summary>
	/// 
	/// </summary>

	public class StressPill : MonoBehaviour
	{
		#region Static Fields
		#endregion
		#region Const Field
		#endregion
		#region Param Fields
		#endregion
		#region Private Fields
		[Header("Anti-Stress")]
		[SerializeField] private float _stress;

		[Space(3)]
		[Header("Object Pool")]
		[SerializeField] private FloatNumbersObjectPool _objectPool;

        [Space(3)]
        [Header("Offset FloatPoint")]
        [SerializeField] private Vector3 _offsetFloatPoint;
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
                GameObject _floatPoint = _objectPool.GetPooledObject();
                // Imprimimos el valor que deseamos mostrar
                _floatPoint.GetComponentInChildren<TextMeshProUGUI>().text = "-1";

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
                // Modificaremos el Estres
                StressManager.Instance.LessStress(_stress);
                //Destroy(gameObject);
            }
		}
		#endregion
		#region Public Methods
		#endregion
	}
}