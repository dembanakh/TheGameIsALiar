using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_Crossroads : MonoBehaviour
{
    public float leftRotationAngle;
    public float rightRotationAngle;
    public char axis;

    CarriageMotor motor;

    private void Start()
    {
        motor = CarriageManager.instance.motor;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Carriage")) return;

        motor.Turn(GetRotationAngle(motor.horizontalInput), new Normalization(axis, GetNormalizationPosition()));
    }

    public float GetRotationAngle(float horizontalMove)
    {
        if (horizontalMove.Equals(-1f))
            return leftRotationAngle;
        else if (horizontalMove.Equals(0f))
            return 0f;
        else
            return rightRotationAngle;
    }

    private float GetNormalizationPosition()
    {
        if (axis.Equals('x'))
        {
            return transform.position.x;
        } else if (axis.Equals('z'))
        {
            return transform.position.z;
        }
        return 0f;
    }
}
