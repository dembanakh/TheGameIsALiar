using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Level : MonoBehaviour
{
    public int levelNum;
    public TextMeshProUGUI coalsRecord;

    void Start()
    {
        coalsRecord.text = PlayerPrefs.GetInt("Level" + levelNum).ToString();
    }

}
