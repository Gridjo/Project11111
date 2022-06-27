using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bareModul : Moduls
{
    public float damage;
    public int recoil;
    public BuletType bulletType;
    public int junkPerShot;

}
public enum BuletType
{
    single,
    shotgun,
    rocket,
    grenade
}
