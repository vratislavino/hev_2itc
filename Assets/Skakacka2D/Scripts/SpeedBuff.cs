using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBuff : Buff
{
    private void Start() {
        GetComponent<Movement2D>().SpeedBuff = this;
    }

    private void OnDestroy() {
        GetComponent<Movement2D>().SpeedBuff = null;
    }

}
