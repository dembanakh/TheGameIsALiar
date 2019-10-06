using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    #region Singleton

    public static Obstacle instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    #endregion

    public float colliderProbability = 0.5f;

    public bool Randomize()
    {
        return Random.value >= colliderProbability;
    }

    public void Ghost(Collider coll)
    {
        coll.enabled = false;
        StartCoroutine(Reset(coll));
    }

    private IEnumerator Reset(Collider coll)
    {
        yield return new WaitForSeconds(2f);
        coll.enabled = true;
    }
}
