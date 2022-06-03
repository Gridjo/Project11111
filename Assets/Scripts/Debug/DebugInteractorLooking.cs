using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugInteractorLooking : MonoBehaviour
{
    // Start is called before the first frame update

    public static void Debug_HEnter(bool isRightHand)
    {
        Debug.Log($"HoverEnter is execpted. Right: {isRightHand}");
    }

    public static void Debug_HExit(bool isRightHand)
    {
        Debug.Log($"HoverExit is execpted. Right: {isRightHand}");
    }

    public static void Debug_SEnter(bool isRightHand)
    {
        Debug.Log($"SelectedEnter is execpted. Right: {isRightHand}");
    }

    public static void Debug_SExit(bool isRightHand)
    {
        Debug.Log($"SelectedExit is execpted. Right: {isRightHand}");
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
