using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Suicide : MonoBehaviour
{

   
    private void OnTriggerEnter(Collider collision)
    {

        if (collision.gameObject.tag == "ggwp")
        {
            Debug.Log("EnTER");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void OnTriggerExit(Collider collision)
    {

        if (collision.gameObject.tag == "ggwp")
        {
            Debug.Log("EnTER");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void OnTriggerStay(Collider collision)
    {

        if (collision.gameObject.tag == "ggwp")
        {
            Debug.Log("EnTER");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
