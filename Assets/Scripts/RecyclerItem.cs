using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecyclerItem : MonoBehaviour
{
    [Header("Recycler Settings")]
    [Tooltip("How much scraps be get by player after recycling this item.")]
    public int RecyclerCost;

    private Scrap scraps;

    public Scrap Scrap => scraps;

    private void Start()
    {
        Scrap scrap = new Scrap();
        scrap.AmountScrap = RecyclerCost;
    }
}
