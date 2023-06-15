using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BuffCreator : MonoBehaviour
{
    [SerializeField]
    private BuffType buffType;
    
    [SerializeField]
    private float duration;

    static Dictionary<BuffType, Type> typeByBuffType = new Dictionary<BuffType, Type>() {
        { BuffType.Speed, typeof(SpeedBuff) }
    };

    private void OnTriggerEnter2D(Collider2D col) {
        var player = col.GetComponent<Movement2D>();
        if (player != null) {

            var buff = (Buff)player.gameObject.GetComponent(typeByBuffType[buffType]);
            if(buff != null) {
                buff.Pick(duration, buffType);
            } else {
                buff = (Buff)player.gameObject.AddComponent(typeByBuffType[buffType]);
                buff.Pick(duration, buffType);
            }

        }

    }




}
