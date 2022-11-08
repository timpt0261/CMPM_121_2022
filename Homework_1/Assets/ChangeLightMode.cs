using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UIElements;

public class ChangeLightMode : MonoBehaviour
{
    public Light daylight;
    public List<Light> Chandeliers;
    private VisualElement frame_2;
    private VisualElement frame_3;
    private Slider day_slider;
    private Slider chandelier_slider;
    private Transform dt;
    private void Awake()
    {
        dt = daylight.transform;
    }
    private void OnEnable()
    {
        var uiDocument = GetComponent<UIDocument>();
        var rootVisualElement = uiDocument.rootVisualElement;
        frame_2 = rootVisualElement.Q<VisualElement>("Frame_3");
        frame_3 = rootVisualElement.Q<VisualElement>("Frame_4");
        day_slider = frame_2.Q<Slider>("Slider_1");
        chandelier_slider = frame_3.Q<Slider>("Slider_2");
        day_slider.RegisterValueChangedCallback(AdjustDaylight);
        chandelier_slider.RegisterValueChangedCallback(AdjustIntensity);
    }

    private void AdjustDaylight(ChangeEvent<float> ev )
    {
        float rotate_x  = day_slider.value;
        Debug.Log("day slider" + rotate_x);
        Quaternion new_pos = Quaternion.Euler(rotate_x, -70, 0);
        daylight.transform.SetPositionAndRotation(daylight.transform.position, new_pos);

    }
    void AdjustIntensity(ChangeEvent<float> ev) 
    {
        float intensity = chandelier_slider.value;
        Debug.Log("intensity: " + intensity);
        Chandeliers.ForEach(x => x.intensity = intensity);
        
    }

}
