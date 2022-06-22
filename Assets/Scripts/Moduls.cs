using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moduls : MonoBehaviour
{
    public bool AlreadyInGun;
    public Rarity Raryti;
    public float durCoef;
    public int junkPrice;
}
public enum Rarity
{
    Common,
    Rare,
    Epic,
    Legendary
}
