using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinalText : MonoBehaviour
{
    public string text;
    public GameObject nextText;

    TextMeshProUGUI finalText;

    private void Start()
    {
        finalText = GetComponent<TextMeshProUGUI>();

        StartCoroutine(Type());
    }

    IEnumerator Type()
    {
        while (text.Length > 0)
        {
            finalText.text += text[0];
            if (text.Length == 1) this.enabled = false;
            text = text.Remove(0, 1);

            yield return new WaitForSeconds(0.05f);
        }

        yield return new WaitForSeconds(2f);

        if (nextText != null)
            nextText.SetActive(true);
    }

}
