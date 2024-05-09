using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllerScript : MonoBehaviour
{
    public float speed = 5.0f;
    public Transform cameraRig = null;
    //public float cameraPos_LF = 0.0f;
    public float mouseSense = 3.5f;

    // Start is called before the first frame update
    void Start()
    {
        //player = GetComponent<CharacterController>();
        cameraRig = GameObject.Find("OVRCameraRig").transform;

        //locks the cursor in place st. when the camera moves, the cursor doesn't move
        //Cursor.lockState = CursorLockMode.Locked;

        //makes the mouse invisible
        //Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Mouse direction
        //Vector2 mouseDirection = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        //camera position is based on the y axis
        //cameraPos_LF = cameraPos_LF - mouseDirection.y * mouseSense;

        //The following if statement basicaly does the clamping, but manually
        //if (cameraPos_LF < -90)
        //{
        //    cameraPos_LF = -90;
        //}
        //else if (cameraPos_LF > 90)
        //{
        //    cameraPos_LF = 90;
        //}

        //camera.localEulerAngles = Vector3.right * cameraPos;
        //transform.Rotate(Vector3.up * mouseDirection.x * mouseSense);

        //Character direction
        //Vector2 movingDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        //Normalize transforms the vector st. it goes from -1 to 1 on all three axis
        //movingDir.Normalize();

        //if (Input.GetKeyDown(KeyCode.UpArrow))
        //{
        //    transform.Rotate(50.0f * Time.deltaTime, 0.0f, 0.0f);
        //}
        //if (Input.GetKeyDown(KeyCode.DownArrow))
        //{
        //    transform.Rotate(-50.0f * Time.deltaTime, 0.0f, 0.0f);
        //}

        // Get the input from the VR headset
        Vector2 headsetDirection = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);

        // Rotate the character controller based on headset rotation
        float rotationY = cameraRig.localEulerAngles.y;
        transform.rotation = Quaternion.Euler(0, rotationY, 0);

        // Calculate movement direction based on headset direction
        Vector3 movement = new Vector3(headsetDirection.x, 0.0f, headsetDirection.y) * speed * Time.deltaTime;

        // Move the character controller
        transform.Translate(movement, Space.Self);
    }
}

