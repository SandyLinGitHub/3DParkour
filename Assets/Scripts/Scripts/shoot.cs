using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lab3Code : MonoBehaviour
{
    public GameObject Barrel;
    public GameObject Bullet;
    public GameObject OVRCameraRig;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (UnityEngine.Input.GetMouseButtonDown(0))
        //{
        //    GameObject newBullet = Instantiate(Bullet, Barrel.transform.position, Barrel.transform.rotation);
        //    newBullet.GetComponent<Rigidbody>().AddForce(transform.up * 1000);

        //      Destroy(newBullet, 4);
        //}

        // Check if the A button on the right Oculus Touch controller is pressed
        if (OVRInput.GetDown(OVRInput.Button.SecondaryThumbstickDown, OVRInput.Controller.RTouch))
        {
            ShootBullet();
        }
    }
    void ShootBullet()
    {
        // Instantiate a new bullet at the barrel's position and rotation
        GameObject newBullet = Instantiate(Bullet, Barrel.transform.position, Barrel.transform.rotation);

        // Add force to the bullet to shoot it out
        newBullet.GetComponent<Rigidbody>().AddForce(transform.up * 1000);

        // Destroy the bullet after 4 seconds
        Destroy(newBullet, 4);
    }
}
