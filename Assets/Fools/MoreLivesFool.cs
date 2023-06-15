using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoreLivesFool : NormalFool
{
    [SerializeField]
    protected int maxLives = 2;

    protected int currentLives;

    protected override void Start()
    {
        base.Start();
        currentLives = maxLives;    
    }

    protected override void ReactToClick() {
        MinusLife();
        if(currentLives == 0) {
            base.ReactToClick();
            currentLives = maxLives;
        }
    }

    protected virtual void MinusLife() {
        currentLives--;
    }

}
