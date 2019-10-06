using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoalManager : MonoBehaviour
{
    #region Singleton

    public static CoalManager instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    #endregion

    public Transform shootPoint;
    public GameObject[] coalPrefabs;

    public GameObject GetCoalPrefab()
    {
        int randomIdx = Random.Range(0, coalPrefabs.Length);
        return coalPrefabs[randomIdx];
    }

    public GameObject InstantiateCoalBulletPrefab(float force)
    {
        GameObject coal = Instantiate(GetCoalPrefab(), shootPoint.position, shootPoint.rotation);
        coal.tag = "CoalBullet";
        coal.AddComponent<SphereCollider>().isTrigger = true;
        coal.AddComponent<CoalBullet>();
        Rigidbody coalRigidbody = coal.AddComponent<Rigidbody>();
        coalRigidbody.AddForce(force * shootPoint.forward, ForceMode.Impulse);
        return coal;
    }
}
