using UnityEngine;

public class End : MonoBehaviour
{
    public GUI gui;

    private void OnTriggerEnter(Collider other)
    {
        Rigidbody rb = gameObject.GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        GUI.gui.EndGame();
    }
}
