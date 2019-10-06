using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeCredits : MonoBehaviour
{
    public static bool play = false;

    public GameObject noSignalImage;

    public void OnAnimationEnd()
    {
        noSignalImage.SetActive(true);
        GameManager.instance.levelMusic.Stop();
        gameObject.SetActive(false);
    }
}
