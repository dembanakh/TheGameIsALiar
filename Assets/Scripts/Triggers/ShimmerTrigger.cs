using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShimmerTrigger : MonoBehaviour
{
    public Shimmer shimmer;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Carriage")) return;

        shimmer.enabled = true;
    }
}
