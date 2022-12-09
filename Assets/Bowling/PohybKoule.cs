using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PohybKoule : MonoBehaviour
{
    [SerializeField]
    int velikostSily = 1000;

    [SerializeField]
    int explosionRadius = 3;

    Rigidbody rigidbody;
    Vector3 movement = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        movement = Vector3.zero;

        if (Input.GetKey(KeyCode.A))
            movement += Vector3.left;

        if (Input.GetKey(KeyCode.D))
            movement += Vector3.right;

        rigidbody.AddForce(movement * velikostSily * Time.deltaTime);


        if (Input.GetKey(KeyCode.Space))
        {
            var colliders = Physics.OverlapSphere(transform.position, explosionRadius);
            foreach(var collider in colliders)
            {
                Debug.Log(collider);
                Rigidbody rb = collider.GetComponentInParent<Rigidbody>();
                if(rb != null)
                {
                    if(rb != rigidbody)
                        rb.AddExplosionForce(10000, transform.position, explosionRadius);
                }
            }
        }

    }
}
