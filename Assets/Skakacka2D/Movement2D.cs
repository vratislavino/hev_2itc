using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement2D : MonoBehaviour
{
    Rigidbody2D rb;

    [SerializeField]
    private float speed = 7;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float xMove = 0;

        if(Input.GetKey(KeyCode.D)) {
            xMove = speed;
        }
        if (Input.GetKey(KeyCode.A)) {
            xMove = -speed;
        }

        rb.velocity = new Vector2(xMove, rb.velocity.y);
    }
}
