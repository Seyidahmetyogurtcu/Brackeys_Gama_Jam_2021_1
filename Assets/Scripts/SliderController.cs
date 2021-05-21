using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    public Text text;
    public Slider slider;
    public AudioSource audioSource;
    void Update()
    {
        text.text = "Volume: " + slider.value.ToString() + "/" + slider.maxValue;
        audioSource.volume = slider.value / 100;
    }
}
