using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Suicide : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("suicideeeeeee");
        if (other.gameObject.tag == "ggwp")
        {
            Debug.Log("suicide is not an exit");
            Platform.HeetPoints = 0;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("suicideeeeeee");
        if (other.gameObject.tag == "ggwp")
        {
            Debug.Log("suicide is not an exit");
            Platform.HeetPoints = 0;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("suicideeeeeee");
        if (other.gameObject.tag == "ggwp")
        {
            Debug.Log("suicide is not an exit");
            Platform.HeetPoints = 0;
        }
    }
}
