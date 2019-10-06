using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Level01Guide : MonoBehaviour
{
    public GameObject guideScreen;
    public TextMeshProUGUI instructions;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Carriage")) return;
        
        if (gameObject.name.Equals("ControlsGuide") && PlayerPrefs.GetInt("Guide") == 0)
        {
            StartCoroutine(ControlsGuide());
        } else if (gameObject.name.Equals("ShootGuide") && PlayerPrefs.GetInt("Guide") == 1)
        {
            StartCoroutine(ShootGuide());
        }
    }

    IEnumerator ControlsGuide()
    {
        instructions.text = "When you approach a crossroads press W or up-arrow to move forward, A or left-arrow to move to the left and D or right-arrow to move to the right.";
        guideScreen.SetActive(true);
        Time.timeScale = 0f;
        
        yield return new WaitForSecondsRealtime(5f);

        Time.timeScale = 1f;
        guideScreen.SetActive(false);

        PlayerPrefs.SetInt("Guide", 1);
        Destroy(gameObject);
    }

    IEnumerator ShootGuide()
    {
        instructions.text = "When you see an obstacle, you have 2 options: the first is to shoot a piece of coal at it (if you have any) to destroy the obstacle; the second is to risk. The game is a good liar: the obstacle may be a ghost as well as a real danger... ";
        guideScreen.SetActive(true);
        Time.timeScale = 0f;

        yield return new WaitForSecondsRealtime(10f);

        Time.timeScale = 1f;
        guideScreen.SetActive(false);
        PlayerPrefs.SetInt("Guide", 2);
        Destroy(gameObject);
    }
}
