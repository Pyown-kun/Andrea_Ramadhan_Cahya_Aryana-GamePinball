using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LauncerController : MonoBehaviour
{

    public Collider bola;
    public KeyCode input;
    public float force;

    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider == bola)
        {
            ReadInput(bola);
        }

    }

    private void ReadInput(Collider collider)
    {
        if (Input.GetKey(input))
        {
            collider.GetComponent<Rigidbody>().AddForce(Vector3.forward*force);
        }
    }

}
