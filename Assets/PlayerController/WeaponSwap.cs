using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WeaponSwap : MonoBehaviour
{
    public event Action<Weapon> WeaponChanged;

    List<Weapon> weapons;

    public List<Weapon> Weapons { 
        get { 
            if(weapons == null) {
                weapons = GetComponentsInChildren<Weapon>(true).ToList();
            }
            return weapons;    
        } 
    }

    int currentIndex;

    // Start is called before the first frame update
    void Start()
    {
        ActivateWeapon(0);
    }

    private void DeactivateAllWeapons() {
        Weapons.ForEach(weapon => weapon.gameObject.SetActive(false));
    }

    private void ActivateWeapon(int index) {
        if (Weapons[currentIndex].IsReloading)
            return;

        DeactivateAllWeapons();
        currentIndex = index;
        Weapons[index].gameObject.SetActive(true);
        WeaponChanged?.Invoke(Weapons[index]);
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Alpha1)) { ActivateWeapon(0); }
        if (Input.GetKeyDown(KeyCode.Alpha2)) { ActivateWeapon(1); }
        if (Input.GetKeyDown(KeyCode.Alpha3)) { ActivateWeapon(2); }

        int koleckoMysi = (int)Input.mouseScrollDelta.y;
        if (koleckoMysi != 0) {
            koleckoMysi /= Mathf.Abs(koleckoMysi);
            currentIndex += koleckoMysi;
            if(currentIndex < 0)
                currentIndex = 2;
            if (currentIndex > 2)
                currentIndex = 0;

            ActivateWeapon(currentIndex);
        } 
    }
}
