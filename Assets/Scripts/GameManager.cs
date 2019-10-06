using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    #region Singleton

    public static GameManager instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    #endregion

    public CarriageManager carriage;
    public TextMeshProUGUI coalPickedText;
    public TextMeshProUGUI preparationText;
    public TextMeshProUGUI currentLevelText;
    public TextMeshProUGUI finalCoalPickedText;
    public AudioSource coalPickupSound;
    public GameObject pauseScreen;
    public GameObject fadeOutScreen;
    public GameObject fakeCreditsScreen;
    public GameObject hitEffectPrefab;
    public AudioSource hitEffectSound;
    public AudioSource levelMusic;
    public GameObject cartLight;

    public int coalPicked { get; private set; }

    int currentLevel;
    bool gameStarted;
    bool isPaused;

    private void Start()
    {
        if (FakeCredits.play)
        {
            fakeCreditsScreen.SetActive(true);
        } else
        {
            LateStart();
        }
        
    }

    public void LateStart()
    {
        levelMusic.Play();
        currentLevel = int.Parse(SceneManager.GetActiveScene().name.Remove(0, 5));
        Preparation(starting: true);
        coalPicked = 0;
        gameStarted = false;
        isPaused = false;
        ShowCoalPicked();
    }

    void Preparation(bool starting)
    {
        if (starting)
        {
            string level = "LEVEL " + currentLevel;
            preparationText.text = level;
            currentLevelText.text = level;

            preparationText.gameObject.SetActive(true);
        } else
        {
            preparationText.text = "3";

            preparationText.gameObject.SetActive(true);
        }
    }

    public void StartGame(bool starting)
    {
        carriage.TogglePause(isPaused);
        if (starting)
        {
            carriage.enabled = true;
            currentLevelText.gameObject.SetActive(true);
            gameStarted = true;
        }
    }

    private void Update()
    {
        if (Input.GetButtonDown("Cancel") && gameStarted)
        {
            TogglePause();
        }
    }

    private void TogglePause()
    {
        isPaused = !isPaused;
        if (isPaused)
            carriage.TogglePause(true);
        pauseScreen.SetActive(isPaused);
        if (!isPaused)
            Preparation(starting: false);
    }

    public void PickupCoal()
    {
        coalPickupSound.Play();
        coalPicked++;
        ShowCoalPicked();
    }

    public void ShootCoal()
    {
        coalPicked--;
        ShowCoalPicked();
    }

    void ShowCoalPicked()
    {
        coalPickedText.text = coalPicked.ToString();
    }

    public void FinishCurrentLevel(GameObject robotic, GameObject cam, Transform mineCartTop)
    {
        if (currentLevel.Equals(PlayerPrefs.GetInt("Level")))
            PlayerPrefs.SetInt("Level", currentLevel + 1);

        if (coalPicked > PlayerPrefs.GetInt("Level" + currentLevel))
            PlayerPrefs.SetInt("Level" + currentLevel, coalPicked);

        FakeCredits.play = true;

        StartCoroutine(CinematicPart(robotic, cam, mineCartTop));
    }

    IEnumerator CinematicPart(GameObject robotic, GameObject cam, Transform mineCartTop)
    {
        finalCoalPickedText.text = coalPicked.ToString();
        cartLight.SetActive(false);
        levelMusic.Stop();
        robotic.SetActive(true);
        cam.SetActive(true);
        coalPickedText.transform.parent.gameObject.SetActive(false);
        carriage.AdjustPosition(robotic.transform.position.x, 0.5f, robotic.transform.position.z);

        yield return new WaitForSeconds(5.5f);

        mineCartTop.parent = robotic.transform;

        yield return new WaitForSeconds(2f);

        fadeOutScreen.SetActive(true);

        yield return new WaitForSeconds(1.5f);

        SceneManager.LoadScene(currentLevel + 1);
    }

    /*
     * BUTTONS
     */

    public void Back()
    {
        TogglePause();
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        FakeCredits.play = false;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
