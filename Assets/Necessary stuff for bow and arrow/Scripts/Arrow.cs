using UnityEngine;

public class Arrow : MonoBehaviour
{
    public Transform tip = null;
    public Rigidbody rbArrow = null;
    public bool stopped = false;
    public Vector3 last_pos = Vector3.zero;
    public float speed = 3000.0f;

    public void Start()
    {
        rbArrow = GetComponent<Rigidbody>();
    }

    public void FixedUpdate()
    {
        // if stopped, do nothing
        if (stopped)
        {
            return;
        }

        // Quaternion <- keeps rotation inside 4x4 matrix
        rbArrow.MoveRotation(Quaternion.LookRotation(rbArrow.velocity, transform.up));

        // collision check
        if(Physics.Linecast(last_pos, tip.position))
        {
            Stop();
        }
        last_pos = tip.position;
    }

    public void Stop()
    {
        stopped = true;
        rbArrow.isKinematic = true;
        rbArrow.useGravity = false;
    }

    public void Fire(float force)
    {
        stopped = false;
        rbArrow.isKinematic = false;
        rbArrow.useGravity = true;

        // to disconnect from bow (parent)
        transform.parent = null;
        rbArrow.AddForce(transform.forward * force * speed);

        Destroy(gameObject, 10.0f);
    }

}
