using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lab3Code : MonoBehaviour
{
    public GameObject Barrel;
    public GameObject Ball;
    public GameObject OVRCameraRig;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (UnityEngine.Input.GetMouseButtonDown(0))
        {
            GameObject newBullet = Instantiate(Ball, Barrel.transform.position, Barrel.transform.rotation);
            newBullet.GetComponent<Rigidbody>().AddForce(transform.up * 1000);

            Destroy(newBullet, 4);
        }
    }
}
