using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public event Action<Weapon> AmmoChanged;
    public event Action ReloadStarted;
    public event Action ReloadFinished;
    public event Action<float> ReloadProgressChanged;


    [SerializeField]
    protected int maxPocetNaboju;

    public int MaxPocetNaboju => maxPocetNaboju;

    protected int currPocetNaboju;

    public int CurrPocetNaboju {
        get { return currPocetNaboju; }
        protected set { 
            currPocetNaboju = value;
            Debug.Log(currPocetNaboju);
            AmmoChanged?.Invoke(this);
        }
    }

    [SerializeField]
    protected float shootCooldown;
    protected float currShootCooldown;

    [SerializeField]
    protected float reloadTime;
    protected float currReloadTime;

    [SerializeField]
    protected int damage;

    [SerializeField]
    protected GameObject bulletPrefab;
    [SerializeField]
    protected Transform shootPoint;

    [SerializeField]
    protected float bulletSpeed;

    [SerializeField]
    protected Sprite sprite;

    public Sprite Sprite => sprite;

    public string Name => GetType().Name;

    public bool IsReloading => currReloadTime > 0;

    void Start()
    {
        Reload();
    }

    public virtual void Update()
    {
        ProcessTimers();

        ProcessShootInput();

        ProcessReloadInput();
    }
    protected void ProcessTimers()
    {
        currShootCooldown -= Time.deltaTime;

        if (currReloadTime > 0)
        {
            currReloadTime -= Time.deltaTime;

            ReloadProgressChanged?.Invoke(currReloadTime / reloadTime);

            if (currReloadTime < 0)
                Reload();
        } 
    }

    protected virtual void ProcessShootInput()
    { // semi auto støelba
        if(Input.GetButtonDown("Fire1"))
        {
            if (CurrPocetNaboju > 0 && currShootCooldown <= 0 && currReloadTime <= 0)
                Shoot();
        }
    }

    protected void ProcessReloadInput()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            if(CurrPocetNaboju < maxPocetNaboju && currReloadTime <= 0)
            {
                currReloadTime = reloadTime;
                ReloadStarted?.Invoke();
            }
        }
    }


    protected virtual void Shoot()
    {
        var bullet = Instantiate(bulletPrefab, shootPoint.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody>().AddForce(transform.forward * bulletSpeed, ForceMode.Impulse);

        CurrPocetNaboju--;
        currShootCooldown = shootCooldown;
    }

    protected void Reload()
    {
        CurrPocetNaboju = maxPocetNaboju;
        ReloadFinished?.Invoke();
    }
}
