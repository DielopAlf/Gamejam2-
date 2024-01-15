using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [Header("TMPro")]
    [SerializeField] private TextMeshProUGUI _scoreText;
    [Space(3)]
    [Header("Score")]
    [SerializeField] private int m_score;

    // Start is called before the first frame update
    void Start()
    {
        _scoreText.text = "00000".PadLeft(5, '0');
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ModifyScore(int amount)
    {
        m_score += amount;
        _scoreText.text = m_score.ToString().PadLeft(5, '0');
    }
}
