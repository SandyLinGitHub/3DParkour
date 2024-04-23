using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5.0f;
    public Transform camera = null;
    public CharacterController player = null;
    public float cameraPos = 0.0f;
    public float mouseSense = 3.5f;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<CharacterController>();
        camera = GameObject.Find("Main Camera").transform;

        //locks the cursor in place st. when the camera moves, the cursor doesn't move
        Cursor.lockState = CursorLockMode.Locked;

        //makes the mouse invisible
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Mouse direction
        Vector2 mouseDirection = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        //camera position is based on the y axis
        cameraPos = cameraPos - mouseDirection.y * mouseSense;

        //The following if statement basicaly does the clamping, but manually
        if (cameraPos < -90)
        {
            cameraPos = -90;
        }
        else if (cameraPos > 90)
        {
            cameraPos = 90;
        }
        camera.localEulerAngles = Vector3.right * cameraPos;
        transform.Rotate(Vector3.up * mouseDirection.x * mouseSense);

        //Character direction
        Vector2 movingDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        //Normalize transforms the vector st. it goes from -1 to 1 on all three axis
        movingDir.Normalize();

        //movement of the charactor in the x and z direction.
        //the reason why its movingDir.y instead of z is because movingDir is a 2D vector, 
        //so the y value within movingDir represents the z coordinate movement in 3D. 
        Vector3 pace = new Vector3(movingDir.x * speed, 0, movingDir.y * speed);

        //the player moves at a smooth pace when multiplied by Time 
        player.Move(pace * Time.deltaTime);

    }
}
