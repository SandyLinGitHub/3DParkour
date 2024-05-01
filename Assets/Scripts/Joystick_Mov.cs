using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joystick_Mov : MonoBehaviour
{
    public CharacterController player;
    public float jumpForce = 8.0f;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 joystickAxis = OVRInput.Get(OVRInput.RawAxis2D.RThumbstick, OVRInput.Controller.RTouch);
        Vector3 newDir = new Vector3(joystickAxis.x, 0.0f, joystickAxis.y);
        player.Move(newDir * 2.0f * Time.deltaTime);

        if (OVRInput.GetDown(OVRInput.Button.One, OVRInput.Controller.RTouch)) // Button A on Oculus controller
        {
            Debug.Log("Jump!!!");
            Jump();
        }
    }
    void Jump()
    {
        // Check if the player is grounded before jumping to avoid double jumps
        if (player.isGrounded)
        {
            Vector3 jumpVector = Vector3.up * jumpForce*100;
            //player.Move(jumpVector);
            Rigidbody jumper = GetComponent<Rigidbody>();
            jumper.AddForce(jumpVector);
        }
    }
}
