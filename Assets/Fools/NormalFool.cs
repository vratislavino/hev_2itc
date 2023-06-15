using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalFool : Fool
{
    protected override void Move() {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    protected override void ReactToClick() {
        ResetFool();
    }
}
