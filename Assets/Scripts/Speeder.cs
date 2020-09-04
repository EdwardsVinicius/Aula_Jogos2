using UnityEngine;

public class Speeder : MonoBehaviour
{
    public float force = 20;
    public ForceMode forceMode;
    Rigidbody rb;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();    
    }

    void OnTriggerEnter(Collider other)
    {
        rb.AddForce(Vector3.forward * force, forceMode);
    }
}
