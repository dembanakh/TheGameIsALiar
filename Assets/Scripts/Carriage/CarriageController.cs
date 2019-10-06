using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CarriageMotor))]
public class CarriageController : MonoBehaviour
{
    CarriageMotor motor;

    public float inputInfluenceTime = 2f;

    private float inputCountdown = 0f;

    private void Start()
    {
        motor = GetComponent<CarriageMotor>();
    }

    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float forward = Input.GetAxisRaw("Vertical");

        if (forward.Equals(1f))
        {
            if (inputCountdown <= 0f)
                motor.horizontalInput = 0f;
        } else if (!horizontal.Equals(0f))
        {
            if (inputCountdown <= 0f)
                motor.horizontalInput = horizontal;
        }

        HandleCountdown();
    }

    void HandleCountdown()
    {
        if (inputCountdown > 0f)
        {
            inputCountdown -= Time.deltaTime;
            if (inputCountdown <= 0f)
            {
                motor.horizontalInput = 0f;
            }
        }
    }
}
