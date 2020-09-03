using System.Collections;
using UnityEngine;

public class Ground : MonoBehaviour
{
    public Transform startPoint;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (rb) StartCoroutine(Reset(rb));
        other.transform.position = startPoint.position;
    }

    IEnumerator Reset (Rigidbody rb)
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
 
        yield return new WaitForFixedUpdate();
 
        // Transport it
        rb.transform.position = startPoint.position;
        rb.transform.rotation = Quaternion.identity;
    }
}
