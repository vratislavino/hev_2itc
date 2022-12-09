using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Transform t;

    [SerializeField]
    private float speed;

    [SerializeField]
    private float border;

    // Start is called before the first frame update
    void Start()
    {
        t = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move = Vector3.zero;

        if (Input.GetKey(KeyCode.A))
            move.x = -1;

        if (Input.GetKey(KeyCode.D))
            move.x = 1;

        t.position += move * speed * Time.deltaTime;

        if (t.position.x < -border)
            t.position = new Vector3(-border, t.position.y, t.position.z);

        if (t.position.x > border)
            t.position = new Vector3(border, t.position.y, t.position.z);


    }
}
