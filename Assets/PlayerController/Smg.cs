using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smg : Weapon
{
    protected override void ProcessShootInput() {
        
        if(Input.GetButton("Fire1")) {
            if(currPocetNaboju > 0 && currShootCooldown <= 0 && currReloadTime <= 0) {
                Shoot();
            }
        }
    }
}
