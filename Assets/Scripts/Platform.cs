using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Platform : MonoBehaviour
{
    public float HeetPoints = 100, MaxHeetPoints = 100;

    // Start is called before the first frame update
    void Start()
    {
         
    }
    public void GetDamage(float Damage)
    {
        HeetPoints -= Damage;
    }
    // Update is called once per frame
    void Update()
    {
        if (HeetPoints <= 0)
        {
            HeetPoints = MaxHeetPoints;
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            SceneManager.LoadScene("MainMenu");
        }
        
    }
}
