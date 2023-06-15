using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin2D : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col) {
        var move = col.GetComponent<Movement2D>();
        if(move != null) {
            move.AddPoint();
        }
    }
}
