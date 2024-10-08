using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LauncerController : MonoBehaviour
{

    public Collider bola;
    public KeyCode input;
    //public float force;

    public float maxTimeHold;
    public float maxForce;

    private bool isHold = false;

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
            StartCoroutine(StarHold(collider));
        }
    }


    private IEnumerator StarHold(Collider collider)
    {
        isHold = true;

        float force = 0.0f;
        float timeHold = 0.0f;

        while (Input.GetKey(input))
        {
            force = Mathf.Lerp(0, maxForce, timeHold / maxTimeHold);

            yield return new WaitForEndOfFrame();
            timeHold += Time.deltaTime;
        }


        collider.GetComponent<Rigidbody>().AddForce(Vector3.forward * force);
        isHold = false;
    }

}
