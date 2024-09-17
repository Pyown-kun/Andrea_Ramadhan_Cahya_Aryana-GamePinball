using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperController : MonoBehaviour
{

    public Collider bola;
    public float multiplier;
    public Color Color;

    private Renderer renderer;
    private Animator animator;

    private void Start()
    {
        renderer = GetComponent<Renderer>();
        animator = GetComponent<Animator>();

        GetComponent<Renderer>().material.color = Color;
    }

    private void OnCollisionEnter(Collision collision)
    {
       if(collision.collider == bola)
        {
            Rigidbody bolaRig = bola.GetComponent<Rigidbody>();
            bolaRig.velocity *= multiplier;
            //Debug.Log("menyentuh");

            animator.SetTrigger("hit");
        }
    }
}
