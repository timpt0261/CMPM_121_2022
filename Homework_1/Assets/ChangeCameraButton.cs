using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class ChangeCameraButton : MonoBehaviour
{
    public List<Camera> Cameras;
    private VisualElement frame;
    private Button button;

    private void OnEnable()
    {
        var uiDocument = GetComponent<UIDocument>();
        var rootVisualElement = uiDocument.rootVisualElement;
        frame = rootVisualElement.Q<VisualElement>("Frame_1");
        button = frame.Q<Button>("Button_1");
        button.RegisterCallback<ClickEvent>(ev => ChangeCamera());
    }

    int click = 0;
    private void ChangeCamera(){
        EnableCamera(click);
        click++;
        if (click > 3) {
            click = 0;
        }
    }

    private void EnableCamera(int n) {
        Cameras.ForEach(cam => cam.enabled = false);
        Cameras[n].enabled = true;
    }
}
