using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowMovement : MonoBehaviour
{
    [Range(0f, 1f)]
    public float maxOffset = 0.1f;
    [Range(0.001f, 10f)]
    public float speed = 1f;

    private float currentOffset;
    private float direction;

    private void Start()
    {
        direction = -1f;
        currentOffset = -maxOffset;
        transform.Translate(0f, currentOffset, 0f);
    }

    private void Update()
    {
        if (currentOffset <= -maxOffset)
        {
            Move(speed * Time.deltaTime);
            direction = 1f;
        } else if (currentOffset >= maxOffset)
        {
            Move(-speed * Time.deltaTime);
            direction = -1f;
        } else
        {
            Move(direction * speed * Time.deltaTime);
        }
    }

    private void Move(float movement)
    {
        transform.Translate(0f, movement, 0f);
        currentOffset += movement;
    }
}
