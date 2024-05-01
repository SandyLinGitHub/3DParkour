using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Cam : MonoBehaviour
{
    public CharacterController player;
    public GameObject eye;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //Button.One corresponds to one of the Button on the controls
        if (OVRInput.Get(OVRInput.Button.One))
        {
            //pointed forwards
            Vector3 newDir = eye.transform.localRotation * new Vector3(0.0f, 0.0f, 1.0f);
            //0.1, making it move not that fast
            player.Move(newDir * 0.1f);
        }
    }
}
