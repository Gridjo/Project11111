﻿using System.Collections;
using UnityEngine;

namespace HurricaneVR.Framework.Weapons.Guns
{
    public class HVRPistol : HVRGunBase
    {
        protected override void Awake()
        {
            base.Awake();
        }

        public void SetMaxAmmo(int amount)
        {
            GameMaxAmmo = amount;
        }

        //Adding Ammo
        //Return ostatok for ScrapCube
        public int AddAmmo(int amount)
        {
            int ostatok = 0;

                if (GameAmmo < GameMaxAmmo)
                {
                    if (GameAmmo + amount < GameMaxAmmo)
                        GameAmmo += amount;
                    else if (GameAmmo + amount > GameMaxAmmo)
                    {
                        ostatok = GameAmmo + amount - GameMaxAmmo;
                    }
                }
                else
                {
                ostatok = amount;
                }
                return ostatok;
            
            
        }

        //Maybe need to use Update()
        private void FixedUpdate()
        {

        }
    }
}