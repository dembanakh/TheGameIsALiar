using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoalPickupTrigger : MonoBehaviour
{
    public float rotationSpeed = 10f;

    private void Start()
    {
        GameObject coalPrefab = CoalManager.instance.GetCoalPrefab();
        Instantiate(coalPrefab, transform);
    }

    private void Update()
    {
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Carriage")) return;

        GameManager.instance.PickupCoal();

        Destroy(gameObject);
    }
}
