using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoSignal : MonoBehaviour
{
    public void OnAnimationStart()
    {

    }

    public void OnAnimationEnd()
    {
        GameManager.instance.LateStart();
        gameObject.SetActive(false);
    }
}
