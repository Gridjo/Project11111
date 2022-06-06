using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class HandPresends : MonoBehaviour
{
    public bool showController = false;
    public InputDeviceCharacteristics controllerDeviceCharacteristics;
    public GameObject controllerPrefab;
    public GameObject handPrefab;


    private InputDevice targetDevice;
    private List<GameObject> controllerPrefabs = new List<GameObject>();
    private GameObject spawnedController;
    private GameObject spawnedHand;

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
            GameObject prefab = controllerPrefabs.Find(controller => controller.name == targetDevice.name);
            if(prefab)
            {
                spawnedController = Instantiate(prefab, transform);
            }
            else
            {
                spawnedController = Instantiate(controllerPrefabs[0], transform);
            }


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
        targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue);
        if (triggerValue > 0.1f)
            Debug.Log("Trigger pressed " + triggerValue);

        

    }
}
