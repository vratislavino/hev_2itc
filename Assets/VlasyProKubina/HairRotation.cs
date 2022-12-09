using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HairRotation : MonoBehaviour
{
    [SerializeField]
    private float rotationSpeed;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, rotationSpeed, 0);
    }
}
