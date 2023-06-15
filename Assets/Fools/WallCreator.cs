using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCreator : MonoBehaviour
{
    [SerializeField]
    private float radius = 5;

    [SerializeField]
    private float degreeOffset = 2;

    // Start is called before the first frame update
    void Start()
    {
        SpawnWall();
    }

    void SpawnWall() {
        float x, y;
        GameObject piece;
        
        for(float angle = 0; angle <= 360; angle += degreeOffset) {
            x = radius * Mathf.Cos(angle * Mathf.Deg2Rad);
            y = radius * Mathf.Sin(angle * Mathf.Deg2Rad);
            piece = GameObject.CreatePrimitive(PrimitiveType.Cube);
            piece.transform.position = new Vector3(x, 0.5f, y);
            piece.transform.rotation = Quaternion.Euler(0, -angle, 0);
            piece.transform.parent = transform;
        }


    }
}
