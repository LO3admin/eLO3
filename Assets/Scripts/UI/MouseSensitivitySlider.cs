using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class MouseSensitivitySlider : MonoBehaviour
{
    public Camera_Controller cam;
    private Slider slider;

    private void Start()
    {
        slider = GetComponent<Slider>();
        slider.value = cam.sensitivity;
    }
    public void UpdateSensitivity()
    {
        cam.SetSensitivity(slider.value);
    }
}
