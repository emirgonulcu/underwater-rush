using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleScript : MonoBehaviour
{

    private void FixedUpdate()
    {
        transform.position += Vector3.up * 2f * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "BubbleBlocking")
        {
            Destroy(gameObject);
        }
    }
}
