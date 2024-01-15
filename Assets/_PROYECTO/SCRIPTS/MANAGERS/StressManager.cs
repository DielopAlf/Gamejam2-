using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StressManager : MonoBehaviour
{
    [Header("Singleton")]
    private static StressManager _instance;
    public static StressManager Instance { get { return _instance; } }
    [Space(3)]
    [Header("Slider")]
    [SerializeField] private Slider _stressBar;
    [Space(3)]
    [Header("Values")]
    [SerializeField] private float _maxStress = 100.0f;
    [SerializeField] private float _curStress = 0.0f;
    [SerializeField] private float _stressGain;
    [SerializeField] private float  _stressLess;
    [Space(3)]
    [Header("Timer")]
    [SerializeField] private float _timer;
    [SerializeField] private float _timeStress;

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

    void Awake()
    {
        if (_instance is null)
        {
            _instance = this;
        }

        DontDestroyOnLoad(this);
    }

    private void GainStressByTime()
    {
        _curStress += _stressGain;
    }

    public void LessStressByAction()
    {
        _curStress -= _stressLess;
    }
}
