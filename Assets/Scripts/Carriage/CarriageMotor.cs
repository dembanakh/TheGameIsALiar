using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarriageMotor : MonoBehaviour
{
    public float forwardSpeed = 8f;
    public float rotationSpeed = 100f;
    public float wheelRotationSpeed = 200f;
    public GameObject[] wheelsWires;
    public float acceleration = 0.04f;

    public float horizontalInput { get; set; }

    private float requiredRotationAngle;
    private Vector3 requiredEulerRotation;

    private Normalization requiredPosition;

    private float multiplier = 1;

    private void Start()
    {
        horizontalInput = 0f;
        requiredRotationAngle = 0f;
    }

    private void Update()
    {
        float deltaTime = Time.deltaTime;
        multiplier += deltaTime * acceleration;

        transform.Translate(Vector3.forward * forwardSpeed * deltaTime * multiplier);
        foreach (var wire in wheelsWires)
        {
            wire.transform.Rotate(-wheelRotationSpeed * deltaTime * multiplier, 0f, 0f);
        }
        if (requiredRotationAngle.Equals(0f)) return;

        if (requiredRotationAngle > 0f)
        {
            Rotate(1f);
        } else  // requiredRotationAngle < 0f
        {
            Rotate(-1f);
        }
    }

    public void Turn(float turnAngle, Normalization normalization)
    {
        // Rotate carriage at the crossroads
        requiredRotationAngle = turnAngle;
        requiredEulerRotation = transform.eulerAngles + Vector3.up * requiredRotationAngle;
        requiredPosition = normalization;
        horizontalInput = 0f;
    }

    void Rotate(float _sign)
    {
        float frameRotation = _sign * rotationSpeed * Time.deltaTime * multiplier;
        transform.Rotate(Vector3.up * frameRotation);
        requiredRotationAngle -= frameRotation;
        if (_sign * requiredRotationAngle < 0f)
        {
            NormalizeRotation();
            NormalizePosition();
        } 
    }

    void NormalizeRotation()
    {
        requiredRotationAngle = 0f;
        transform.eulerAngles = requiredEulerRotation;
    }

    void NormalizePosition()
    {
        if (requiredPosition.axis.Equals('x'))
        {
            transform.position = new Vector3(requiredPosition.pos, transform.position.y, transform.position.z);
        } else if (requiredPosition.axis.Equals('z'))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, requiredPosition.pos);
        }
    }
}

public class Normalization {
    public float pos;
    public char axis;

    public Normalization(char axis, float pos)
    {
        this.axis = axis;
        this.pos = pos;
    }
}
