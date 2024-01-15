using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    [Header("Static")]
    private static HealthManager _instance;
    public static HealthManager Instance { get { return _instance; } }
    [Space(3)]
    [Header("Slider")]
    [SerializeField] private Slider _healthBar;
    [Space(3)]
    [Header("Values")]
    [SerializeField] private int _maxHealth;
    [SerializeField] private int _curHealth;
    [SerializeField] private int _minHealth;

    // Start is called before the first frame update
    void Start()
    {
        SetUpHealthBar();
    }

    // Update is called once per frame
    void Update()
    {
        if(_curHealth > _maxHealth)
        {
            _curHealth = _maxHealth;
        }else if(_curHealth < _minHealth)
        {
            _curHealth = 0;
        }
    }

    private void SetUpHealthBar()
    {
        _curHealth = _maxHealth;

        _healthBar.maxValue = _maxHealth;
        _healthBar.minValue = _minHealth;
        _healthBar.value = _curHealth;
    }

    public void ModifyHealth(int amount)
    {
        _curHealth += amount;
        _healthBar.value = _curHealth;
    }
}
