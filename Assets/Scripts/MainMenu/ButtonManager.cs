using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public GameObject continueButton;
    public GameObject levelsButton;
    public int NumberOfLevels;

    public Animator canvasMain;
    public Animator canvasLevels;

    private void Start()
    {
        FakeCredits.play = false;
        if (PlayerPrefs.GetInt("Level") == 0)
        {
            continueButton.SetActive(false);
            levelsButton.SetActive(false);
        } else if (PlayerPrefs.GetInt("Level") == NumberOfLevels + 1)
        {
            continueButton.SetActive(false);
        }
    }

    public void NewGame()
    {
        PlayerPrefs.SetInt("Level", 1);
        SceneManager.LoadScene(1);
    }

    public void Continue()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("Level"));
    }

    public void Levels()
    {
        canvasMain.SetTrigger("Out");
        canvasLevels.SetTrigger("In");
    }

    public void Back()
    {
        canvasLevels.SetTrigger("Out");
        canvasMain.SetTrigger("In");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
