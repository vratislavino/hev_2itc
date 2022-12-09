using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;
using System;

public class WeaponDisplay : MonoBehaviour
{
    [SerializeField]
    private Image weaponImage;

    [SerializeField]
    private TMP_Text weaponName;

    [SerializeField]
    private Image bulletImage;

    [SerializeField]
    private TMP_Text ammoCount;

    [SerializeField]
    private Image reloadImage;

    [SerializeField]
    private WeaponSwap weaponSwap;

    void Awake()
    {
        weaponSwap.WeaponChanged += OnWeaponChanged;
        foreach(var weapon in weaponSwap.Weapons) {
            weapon.AmmoChanged += OnAmmoChanged;
            weapon.ReloadStarted += OnReloadStarted;
            weapon.ReloadFinished += OnReloadFinished;
            weapon.ReloadProgressChanged += OnReloadProgressChanged;
        }
    }

    private void OnReloadStarted() {
        reloadImage.gameObject.SetActive(true);
        ammoCount.gameObject.SetActive(false);
    }

    private void OnReloadFinished() {
        reloadImage.gameObject.SetActive(false);
        ammoCount.gameObject.SetActive(true);
    }

    private void OnReloadProgressChanged(float obj) {
        reloadImage.fillAmount = obj;
    }

    private void OnAmmoChanged(Weapon weapon) {
        ammoCount.text = $"{weapon.CurrPocetNaboju}/{weapon.MaxPocetNaboju}";
    }

    private void OnWeaponChanged(Weapon weapon) {
        weaponImage.sprite = weapon.Sprite;
        weaponName.text = weapon.Name;

        OnAmmoChanged(weapon);
    }
}
