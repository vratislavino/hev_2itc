using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buff : MonoBehaviour
{
    protected float duration;
    protected float remains;
    protected float baseMultiplier = 1.2f;
    protected BuffType buffType;
    protected int stacks;

    public virtual void Pick(float duration, BuffType buffType) {
        stacks++;
        remains = duration;
        this.duration = duration;
        this.buffType = buffType;
    }

    public float GetMultiplier() {
        return Mathf.Pow(baseMultiplier, stacks);
    }

    // Update is called once per frame
    void Update()
    {
        if(stacks > 0) {
            remains -= Time.deltaTime;
            if(remains <= 0) {
                stacks--;
                if(stacks > 0) {
                    remains = duration;
                } else {
                    Destroy(this);
                }
            }

        } 
    }
}

public enum BuffType
{
    Speed, Jump, Time
}