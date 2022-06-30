using HurricaneVR.Framework.Weapons.Guns;
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
        private int recoil;
        private int recoilStock;
        private HVRPistol hvrp;

        // Start is called before the first frame update
        void Awake()
        {
        hvrp = gameObject.GetComponent<HVRPistol>();
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
        }

        public void ReloadTextAmmo()
        {
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
                        recoilStock = stm.recoil;
                        recoil = recoilBaree + recoilStock;
                        return;
                    }
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

