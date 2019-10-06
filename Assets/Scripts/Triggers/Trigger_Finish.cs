using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_Finish : MonoBehaviour
{
    public GameObject robotic;
    public GameObject cam;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Carriage")) return;

        CarriageManager.instance.FinishLevel(robotic, cam);

        Destroy(gameObject);
    }
}
