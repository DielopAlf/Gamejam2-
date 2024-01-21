using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ChangeVolumeIcon : MonoBehaviour
{
    [SerializeField] private Sprite normal;
    [SerializeField] private Sprite muted;

    [SerializeField] private Slider slider;

    [SerializeField] private Button button;


    public void Update()
    {
        if (slider.value == 0)
        {
            button.GetComponent<Image>().sprite = muted;
        }
        else
        {
            button.GetComponent<Image>().sprite = normal;
        }
    }
}
