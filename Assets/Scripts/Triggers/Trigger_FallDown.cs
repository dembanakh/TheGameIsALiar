using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_FallDown : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Carriage")) return;

        CarriageManager.instance.FallDown();

        Destroy(gameObject);
    }
}
