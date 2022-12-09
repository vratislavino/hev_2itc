using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HairPoints : MonoBehaviour
{
    [SerializeField]
    private int points;

    public int Points => points;

    [SerializeField]
    private bool isRandom;

    private void Start()
    {
        if (isRandom)
        {
            points = Random.Range(1, 5);
            var rend = transform.GetComponentInChildren<MeshRenderer>();
            rend.material.color = new Color(0, (points*50)/255f, 0);
        }
    }

}
