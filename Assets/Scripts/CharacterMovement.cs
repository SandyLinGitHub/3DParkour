using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OculusCharacterController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    private Rigidbody rb;
    private OVRInput.Controller controller = OVRInput.Controller.LTouch;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Move();
        Jump();
    }

    void Move()
    {
        Vector2 stickInput = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick, controller);
        Vector3 moveDirection = new Vector3(stickInput.x, 0f, stickInput.y).normalized;
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }

    void Jump()
    {
        if (OVRInput.GetDown(OVRInput.Button.One, controller) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}

