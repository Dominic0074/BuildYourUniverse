using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class ControllerHandler : MonoBehaviour
{
    public bool secondary;
    public bool primary;
    public float saveButton = 0f;
    public bool back;
    List<InputDevice> inputDevices = new List<InputDevice>();

    // Start is called before the first frame update
    void Start()
    {
        InitializeInputRenderer();
    }

    public void InitializeInputRenderer()
    {
        InputDevices.GetDevicesWithCharacteristics(InputDeviceCharacteristics.Right | InputDeviceCharacteristics.Controller, inputDevices);
        InputDevices.GetDevicesWithCharacteristics(InputDeviceCharacteristics.Left | InputDeviceCharacteristics.Controller, inputDevices);
        foreach (var inputDevice in inputDevices)
        {
            inputDevice.TryGetFeatureValue(CommonUsages.gripButton, out back);
            inputDevice.TryGetFeatureValue(CommonUsages.secondaryButton, out secondary);
            inputDevice.TryGetFeatureValue(CommonUsages.primaryButton, out primary);
            inputDevice.TryGetFeatureValue(CommonUsages.trigger, out saveButton);
            Debug.Log(inputDevice.name + " " + inputDevice.characteristics);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (inputDevices.Count < 2)
        {
            InitializeInputRenderer();
        }
    }
}
