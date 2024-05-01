using System.Collections;
using UnityEngine;

public class Bow : MonoBehaviour
{
    public GameObject arrowPrefab = null;

    public Animator anime = null;
    public float pullValue = 0.0f;
    public Transform start_pos = null;
    //end = biggest pull 
    public Transform end_pos = null;
    public Transform notch_pos = null;
    public Transform pulland = null;

    public Arrow current = null;

    public void Awake()
    {
        anime = GetComponent<Animator>();
    }

    public void Start()
    {
        // wants arrow to immediately appear
        // a seperate process will occur
        StartCoroutine(createArrow(0.0f));
    }

    public void Update()
    {
        if (!current || !pulland)
        {
            return;
        }
        pullValue = calcPull(pulland);

        pullValue = Mathf.Clamp(pullValue, 0.0f, 1.0f);

        anime.SetFloat("Blend", pullValue);
    }

    public IEnumerator createArrow(float waiting)
    {
        // stops execution until the new WaitForSeconds is finished executing
        // it doesn't make assumptions of where it is running. No clock awareness
        yield return new WaitForSeconds(waiting);

        //creates copy of that prefabricated object at the notch postion of bow
        GameObject newArrow = Instantiate(arrowPrefab, notch_pos);

        //Makes arrow sticking a little out of bow
        newArrow.transform.localPosition = new Vector3(0, 0, 0.425f);
        newArrow.transform.localEulerAngles = Vector3.zero;

        //capturing new arrow component for later use
        current = newArrow.GetComponent<Arrow>();
    }

    public void Pull(Transform hand)
    {
        float distance = Vector3.Distance(hand.position, start_pos.position);
        //pulling back would always be negative, it not, return
        if(distance > 0.15f)
        {
            return;
        }
        pulland = hand;
    }

    public float calcPull(Transform Hand)
    {
        Vector3 direction = end_pos.position - start_pos.position;
        float magnitude = direction.magnitude;
        direction.Normalize();

        //current position - starting position of arrow
        Vector3 pulling = Hand.position - start_pos.position;

        //calculates the Dot Product (commanality of the two products)
        //Cross product calculates the difference between two products
        return Vector3.Dot(pulling, direction)/magnitude;
    }

    public void Release()
    {
        if (pullValue > 0.25f)
        {
            fireArrow();
            pulland = null;
            pullValue = 0.0f;
            anime.SetFloat("Blend", 0.0f);
        }
        if (!current)
        {
            
        }
    }
    public void fireArrow()
    {
        current.Fire(pullValue);
        current = null;
    }
}
