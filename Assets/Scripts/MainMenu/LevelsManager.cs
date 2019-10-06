using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelsManager : MonoBehaviour
{
    public GameObject[] levels;

    private void Start()
    {
        int levelReached = PlayerPrefs.GetInt("Level");
        for (int i = 0; i < levelReached; i++)
            levels[i].SetActive(true);
    }

    public void LoadLevel(int num)
    {
        SceneManager.LoadScene(num);
    }
}
