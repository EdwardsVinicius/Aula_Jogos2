
using UnityEngine;

public class Anel : MonoBehaviour
{
    public GameObject anel;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * 50 * Time.deltaTime, Space.Self);
    }
}
