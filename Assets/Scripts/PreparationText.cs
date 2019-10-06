using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PreparationText : MonoBehaviour
{
    TextMeshProUGUI text;
    bool starting;

    private void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        starting = false;
    }

    public void OnAnimationEnd()
    {
        switch (text.text)
        {
            case "3":
                text.text = "2";
                break;
            case "2":
                text.text = "1";
                break;
            case "1":
                GameManager.instance.StartGame(starting);
                starting = false;
                gameObject.SetActive(false);
                break;
            default:
                text.text = "3";
                starting = true;
                break;
        }
    }
}
