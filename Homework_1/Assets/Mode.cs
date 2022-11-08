using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UIElements;

public class Mode : MonoBehaviour
{
    public Light dir_light;
    public List<Light> Spotlights;
    public List<Light> Chandelier;
    private VisualElement frame;
    private Button button;


    private void Awake()
    {
        Spotlights.ForEach(x => x.intensity = 0);
        Chandelier.ForEach(x => x.intensity = 0);
        dir_light.transform.SetPositionAndRotation(dir_light.transform.position, Quaternion.Euler(50, -70, 0));
    }

    private void OnEnable()
    {
        var uiDocument = GetComponent<UIDocument>();
        var rootVisualElement = uiDocument.rootVisualElement;
        frame = rootVisualElement.Q<VisualElement>("Frame_2");
        button = frame.Q<Button>("Button_2");
        button.RegisterCallback<ClickEvent>(ev => SwitchMode() );
    }

    int mode = 0;
    private void SwitchMode()
    {
        SetScene(mode);
        mode++;
        if (mode > 3)
        {
            mode = 0;
        }
    }
    private void SetScene(int mode) {
        
        switch (mode) {
            case 0:
                //daylight scene
                Debug.Log("Day Light Mode");
                Spotlights.ForEach(x => x.intensity = 0);
                Chandelier.ForEach(x => x.intensity = 0);
                dir_light.transform.SetPositionAndRotation(dir_light.transform.position, Quaternion.Euler(50, -70, 0));
                break;
            case 1:
                // night scene
                Debug.Log("Night Mode");
                Spotlights.ForEach(x => x.intensity = 0);
                Chandelier.ForEach(x => x.intensity = 3);
                dir_light.transform.SetPositionAndRotation(dir_light.transform.position, Quaternion.Euler(-70, -70, 0));
                break;
            case 2:
                // spooky scene
                Debug.Log("Spookey Mode");
                Spotlights.ForEach(x => x.intensity = 16);
                Spotlights[2].intensity = 20;
                Chandelier.ForEach(x => x.intensity = 0);
                dir_light.transform.SetPositionAndRotation(dir_light.transform.position, Quaternion.Euler(-70, -70, 0));
                break;
        }

    
    }

}
