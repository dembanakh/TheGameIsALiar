using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shimmer : MonoBehaviour
{
    public Light cartLight;
    public Animator anim;

    public void Start()
    {
        anim.SetTrigger("Shimmer");
    }

    public void StartToggling()
    {
        anim.enabled = false;
        StartCoroutine(ConstantLightToggling());
    }

    IEnumerator ConstantLightToggling()
    {
        while (true) {
            cartLight.intensity = 6;
            yield return new WaitForSeconds(0.5f);
            cartLight.intensity = 0;
            yield return new WaitForSeconds(0.5f);
        }
    }
}
