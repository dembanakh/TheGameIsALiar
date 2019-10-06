using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class CoalBullet : MonoBehaviour
{

    private void Start()
    {
        StartCoroutine(DieDelay(null));
    }

    IEnumerator DieDelay(GameObject effectPrefab)
    {
        yield return new WaitForSeconds(5f);
        if (effectPrefab != null)
            Destroy(effectPrefab);
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            GameManager.instance.hitEffectSound.Play();
            GameObject effectPrefab = Instantiate(GameManager.instance.hitEffectPrefab, transform.position, Quaternion.identity);
            Destroy(other.gameObject);
            StopAllCoroutines();
            GetComponent<MeshRenderer>().enabled = false;
            DieDelay(effectPrefab);
        }
    }
}
