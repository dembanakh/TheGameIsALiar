using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CarriageMotor))]
[RequireComponent(typeof(Rigidbody))]
public class CarriageManager : MonoBehaviour
{
    #region Singleton

    public static CarriageManager instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        motor = GetComponent<CarriageMotor>();
        controller = GetComponent<CarriageController>();
        shooting = GetComponent<CoalShooting>();
    }

    #endregion

    public GameObject playerCam;
    public Transform mineCartTop;
    public GameObject gameOverScreen;

    [HideInInspector]
    public CarriageMotor motor;
    [HideInInspector]
    public CarriageController controller;
    [HideInInspector]
    public CoalShooting shooting;

    private GameManager gameManager;
    private Rigidbody rb;
    private Obstacle obstacleManager;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        gameManager = GameManager.instance;
        obstacleManager = Obstacle.instance;
        motor.enabled = true;
        controller.enabled = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Collider collider = collision.collider;
        string name = collider.name;

        if (!collider.CompareTag("Obstacle"))
        {
            GameOver(name);
        } else
        {
            bool gameOver = obstacleManager.Randomize();
            print(gameOver);
            if (gameOver)
                GameOver(name);
            else
                obstacleManager.Ghost(collider);
        }
    }

    void GameOver(string name)
    {
        motor.enabled = false;
        rb.isKinematic = true;
        print("GAME OVER (" + name + ")");

        gameOverScreen.SetActive(true);

        shooting.enabled = false;
    }

    public void FallDown()
    {
        // Game Over
        StartCoroutine(StopMotor());

        playerCam.transform.parent = null;
    }

    IEnumerator StopMotor()
    {
        yield return new WaitForSeconds(0.3f);
        motor.enabled = false;
        rb.AddTorque(transform.right * 0.01f);
        rb.useGravity = true;
        yield return new WaitForSeconds(1f);
        GameOver("FallDown");
    }

    public void FinishLevel(GameObject robotic, GameObject cam)
    {
        motor.enabled = false;
        rb.isKinematic = true;
        print("LEVEL COMPLETED");

        gameManager.FinishCurrentLevel(robotic, cam, mineCartTop);
        playerCam.SetActive(false);
    }

    public void TogglePause(bool isPaused)
    {
        motor.enabled = !isPaused;
        shooting.enabled = !isPaused;
    }

    public void AdjustPosition(float x, float y, float z)
    {
        transform.position = new Vector3(x, y, z);
    }
}
