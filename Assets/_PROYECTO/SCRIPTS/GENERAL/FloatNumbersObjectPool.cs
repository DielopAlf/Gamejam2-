using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VictorRivero{

	/// <summary>
	/// 
	/// </summary>

	public class FloatNumbersObjectPool : MonoBehaviour
	{
		#region Static Fields
		private static FloatNumbersObjectPool _instance;
		public static FloatNumbersObjectPool Instance { get { return _instance; } }
		#endregion
		#region Const Field
		#endregion
		#region Param Fields
		#endregion
		#region Private Fields
		[Header("Pooled Objects")]
		[SerializeField]private List<GameObject> _pooledObjects = new List<GameObject> ();
		[SerializeField] private int _amountToPool;

		[Space(2)]
		[Header("GameObject To Pool")]
		[SerializeField] private GameObject _objectToPool;
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
			for (int i = 0; i < _amountToPool; i++)
			{
				GameObject obj = Instantiate(_objectToPool);
				//obj.transform.parent = transform;
				obj.SetActive(false);
				_pooledObjects.Add(obj);
			}
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
		public GameObject GetPooledObject()
		{
			for (int i = 0; i < _pooledObjects.Count; i++)
			{
				if (!_pooledObjects[i].activeInHierarchy)
				{
					return _pooledObjects[i];
				}
			}
			return null;
		}
        #endregion

        /// <summary>
        /// En el Script del Enemigo realizaremos el siguiente paso
		/// para utilizar los objetos de la piscina de objetos
		/// 
		/// En la función cuando el Enemigo muera.
		/// 
		/// GameObject _floatPoint = ObjectPool.Instance.GetPooledObject();
		/// 
		/// if(_floatPoint != null)
		/// {
		///		_floatPoint.transform.position = transform.position;
		///		_floatPoint.SetActive(true);
		///	}
		///	
		/// En lugar de utilizar el Destroy(gameObject);
		/// utilizaremos el gameObject.SetActive(false);
        /// </summary>

    }
}