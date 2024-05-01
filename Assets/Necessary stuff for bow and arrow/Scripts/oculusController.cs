using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oculusController : MonoBehaviour
{
    public Bow myBow = null;
    public GameObject oppositeCon = null;
    public OVRInput.Controller controller = OVRInput.Controller.None;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger, controller))
        {
            myBow.Pull(oppositeCon.transform);
        }
        if (OVRInput.GetUp(OVRInput.Button.SecondaryIndexTrigger, controller))
        {
            myBow.Release();
        }

    }
}
