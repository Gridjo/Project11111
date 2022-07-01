using HurricaneVR.Framework.Weapons.Guns;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

    public class ModulAllInGun : MonoBehaviour
    {
        public float attSpeed;
        public int magCapacity = 10;
        public float damage;
        public int recoilBaree;
        public BuletType bulletType;
        public int junkPerShot = 1;
        public TextMeshPro AmmoText;

        public ModulsInfo stock;
        public bareModul barrel;
        public bodyModul body;

        private int recoil;
        private int recoilStock;
        private HVRPistol hvrp;

        // Start is called before the first frame update
        void Awake()
        {
            hvrp = gameObject.GetComponent<HVRPistol>();
            //ModulsFind();
        }

    private void Start()
    {
        ModulsFind();
    }

    public void ModulsFind()
        {
            FindBody();
            FindBarre();
            FindStock();
            PostModulsFind();
        }

        private void PostModulsFind()
        {
            SetMaxAmmo();
            SetTakeAmmo();
            ReconfigDurability();
        }

        public void ReloadTextAmmo()
        {
        
        if (hvrp.CriticalModuleIsBroken)
            AmmoText.text = "X";
        else
            AmmoText.text = $"{hvrp.GameAmmo}";
        }

        void FindBody()
        {
            for (int x = 0; x < gameObject.transform.childCount; x++)
            {
                for (int i = 0; i < gameObject.transform.GetChild(x).childCount; i++)
                {
                    if (gameObject.transform.GetChild(x).GetChild(i).TryGetComponent<bodyModul>(out bodyModul bodm))
                    {
                        body = bodm;
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
                    if (gameObject.transform.GetChild(x).GetChild(i).TryGetComponent<bareModul>(out bareModul barm))
                    {
                        barrel = barm;
                        recoilBaree = barm.recoil;
                        recoil = recoilBaree;
                        damage = barm.damage;
                        junkPerShot = barm.junkPerShot;
                        bulletType = barm.bulletType;
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
                    if (gameObject.transform.GetChild(x).GetChild(i).TryGetComponent<ModulsInfo>(out ModulsInfo stm))
                    {
                        stock = stm;
                        recoilStock = stm.recoil;
                        recoil = recoilBaree + recoilStock;
                        return;
                    }
                }
            }
        }

    public void ReconfigDurability()
    {
        body.Reconfigurator();
        if (hvrp.TypeGun == TypeGun.rifle)
        {
            barrel.Reconfigurator();
            try
            {
                stock.Reconfigurator();
            } catch (NullReferenceException e)
            {

            }
        }

    }

        private void SetMaxAmmo()
        {
            hvrp.GameMaxAmmo = magCapacity;
        }

        private void SetTakeAmmo()
        {
            hvrp.ShotAmmoTake = junkPerShot;
        }

        private void FixedUpdate()
        {
            ReloadTextAmmo();
        }
    }

