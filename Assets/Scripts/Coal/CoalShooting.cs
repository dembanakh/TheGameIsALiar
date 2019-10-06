using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoalShooting : MonoBehaviour
{
    public float force = 10f;
    public Transform shootPoint;

    GameManager gameManager;
    CoalManager coalManager;

    private void Start()
    {
        gameManager = GameManager.instance;
        coalManager = CoalManager.instance;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1") && gameManager.coalPicked > 0)
        {
            gameManager.ShootCoal();
            Shoot();
        }
    }

    void Shoot()
    {
        coalManager.InstantiateCoalBulletPrefab(force);
    }
}
