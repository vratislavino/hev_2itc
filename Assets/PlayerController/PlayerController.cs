using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Rigidbody rb;

    [SerializeField]
    private float movementSpeed;

    [SerializeField]
    private float jumpForce = 1000;

    [SerializeField]
    private float sensitivity = 3;

    [SerializeField]
    private Transform CameraHolder;

    [SerializeField]
    private Transform GroundCheckPoint;

    private bool isGrounded;

    Vector2 rot;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Move() {

        float horMove = Input.GetAxisRaw("Horizontal");
        float verMove = Input.GetAxisRaw("Vertical");

        if (Input.GetButton("Jump") && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce);
        }


        Vector3 localMove = new Vector3(horMove * movementSpeed, 0, verMove * movementSpeed);
        Vector3 globalMove = transform.TransformDirection(localMove);
        rb.velocity = new Vector3(globalMove.x, rb.velocity.y, globalMove.z);
    }

    void Rotate() {
        var xmove = Input.GetAxis("Mouse X");
        var ymove = Input.GetAxis("Mouse Y");

        rot.x += xmove * sensitivity;
        rot.y += ymove * sensitivity;

        if (rot.y > 70)
            rot.y = 70;

        if (rot.y < -70)
            rot.y = -70;

        transform.rotation = Quaternion.Euler(0, rot.x, 0);
        CameraHolder.localRotation = Quaternion.Euler(-rot.y, 0, 0);
    }

    void CheckGrounded()
    {
        if(Physics.Raycast(GroundCheckPoint.position, Vector3.down, out RaycastHit hit, 0.1f))
        {
            isGrounded = true;
        } else
        {
            isGrounded = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // TODO: dokonèit pohyb, skok aaaaaaaaaaaaaaa otáèení pomocí myši :)
        CheckGrounded();
        Move();
        Rotate();
    }
}
