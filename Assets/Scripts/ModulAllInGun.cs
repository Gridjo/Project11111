using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModulAllInGun : MonoBehaviour
{
    public float attSpeed;
    public int magCapacity;
    public float damage;
    public int recoilBaree;
    public BuletType bulletType;
    public int junkPerShot;
    private int recoil;
    private int recoilStock;
    // Start is called before the first frame update
    void Awake()
    {
        FindBody();
        FindBarre();
        FindStock();

    }
    void FindBody()
    {
        for (int x = 0; x < gameObject.transform.childCount; x++)
        {
            for (int i = 0; i < gameObject.transform.GetChild(x).childCount; i++)
            {
                if (gameObject.transform.GetChild(x).TryGetComponent<bodyModul>(out bodyModul bodm))
                {
                    attSpeed = bodm.attSpeed;
                    magCapacity = bodm.magCapacity;
                    return;
                }
            }
        }
    }
    void FindBarre()
    {
        for (int x = 0; x < gameObject.transform.childCount; x++)
        {
            for (int i = 0; i < gameObject.transform.GetChild(x).childCount; i++)
            {
                if (gameObject.transform.GetChild(x).TryGetComponent<bareModul>(out bareModul barm))
                {
                    recoilBaree = barm.recoil;
                    recoil = recoilBaree;
                    damage = barm.damage;
                    junkPerShot = barm.junkPerShot;
                    return;
                }
            }
        }
    }
    void FindStock()
    {
        for (int x = 0; x < gameObject.transform.childCount; x++)
        {
            for (int i = 0; i < gameObject.transform.GetChild(x).childCount; i++)
            {
                if (gameObject.transform.GetChild(x).TryGetComponent<ModulsInfo>(out ModulsInfo stm))
                {
                    recoilStock = stm.recoil;
                    recoil = recoilBaree + recoilStock;
                    return;
                }
            }
        }
    }

}
