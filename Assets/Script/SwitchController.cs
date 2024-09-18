using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchController : MonoBehaviour
{

    public Collider bola;
    public Material OffMaterial;
    public Material OnMaterial;

    private bool isOn;
    private Renderer renderer;



    // Start is called before the first frame update
    private void Start()
    {
        renderer = GetComponent<Renderer>();
        Set(false);
        //Debug.Log("Switch Mati");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == bola)
        {
            StartCoroutine(Blink(2));
        }
    }

    private void Set(bool active)
    {
        isOn = active;

        if (isOn == true)
        {
            renderer.material = OnMaterial;
            //Debug.Log("switch Hidup");
        }
        else
        {
            renderer.material = OffMaterial;
        }
    }

    private IEnumerator Blink(int times)
    {
        int BlinkTimes = times * 2;

        for (int i = 0; i < BlinkTimes; i++)
        {
            Set(!isOn);
            yield return new WaitForSeconds(0.5f);
        }
    }
}
