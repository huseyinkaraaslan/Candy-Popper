using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float time;
    private Slider slider;

    private void Awake()
    {
        slider = GameObject.Find("Timer").GetComponent<Slider>();
    }

    void Start()
    {
        slider.maxValue = 30;
        slider.minValue = 0;
        slider.wholeNumbers = false;
        slider.value = slider.maxValue;
        time = slider.value;
    }

    // Update is called once per frame
    void Update()
    {
        if(slider.value > slider.minValue)
        {
            time -= Time.deltaTime;
            slider.value = time; 
        }
    }
}
