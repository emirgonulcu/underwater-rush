using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentMovement : MonoBehaviour
{
    public float speed = 1f;

    private void FixedUpdate()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
    }
}
