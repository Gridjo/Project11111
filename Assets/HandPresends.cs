using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class HandPresends : MonoBehaviour
{
    private InputDevice targetDevice;
    // Start is called before the first frame update
    void Start()
    {
        List<InputDevice> devises = new List<InputDevice>();
        InputDeviceCharacteristics rightControllerCharacteristic = InputDeviceCharacteristics.Right | InputDeviceCharacteristics.Controller;

        InputDevices.GetDevicesWithCharacteristics(rightControllerCharacteristic, devises) ; 

        foreach (var item in devises)
        {
            Debug.Log(item.name + item.characteristics);
        }

        if (devises.Count > 0)
        {
            targetDevice = devises[0];
        } 

    }

    // Update is called once per frame
    void Update()
    {
        targetDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool primaryButtonValue);
        if (primaryButtonValue)
        {
            Debug.Log("Pressing Primery Button");
        }
        
        targetDevice.TryGetFeatureValue(CommonUsages)

    }
}
