using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Suicide : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "ggwp")
        {
            Debug.Log("EnTER");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void OnCollisionExit(Collision collision)
    {

        if (collision.gameObject.tag == "ggwp")
        {
            Debug.Log("EnTER");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void OnCollisionStay(Collision collision)
    {

        if (collision.gameObject.tag == "ggwp")
        {
            Debug.Log("EnTER");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
