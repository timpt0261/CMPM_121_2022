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
        frame_2 = rootVisualElement.Q<VisualElement>("Frame_2");
        frame_3 = rootVisualElement.Q<VisualElement>("Frame_3");
        day_slider = frame_2.Q<Slider>("Slider_1");
        chandelier_slider = frame_3.Q<Slider>("Slider_2");
        day_slider.RegisterCallback<ClickEvent>(ev => AdjustDaylight());
        chandelier_slider.RegisterCallback< ClickEvent > (ev => AdjustIntensity());
    }

    void AdjustDaylight()
    {
        Vector3 pos = new Vector3(day_slider.value, -70, 0);
        daylight.transform.Rotate(pos);
    }
    void AdjustIntensity() { 
    
    }

}
