using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVariables : MonoBehaviour
{
    private int scrapsHave;
    public static PlayerVariables Instance;

    private void Awake()
    {
        Instance = this;
    }

    public int GetScrapsAmount()
    {
        return scrapsHave;
    }    

    public void AddScraps(RecyclerItem item)
    {
        if (item.RecyclerCost > 0)
        {
            scrapsHave += item.RecyclerCost;
            Debug.Log(scrapsHave);
        }
        else
            Debug.LogError($"{item.gameObject.name} has cost is {item.RecyclerCost}");
    }    
}
