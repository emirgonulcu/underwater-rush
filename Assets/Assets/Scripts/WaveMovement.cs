using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveMovement : MonoBehaviour
{
    public float speed = 3f;

    Collider2D main_coll;

    private void Awake()
    {
        main_coll= GetComponent<Collider2D>();
    }

    private void FixedUpdate()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Destroy")
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Destroy")
        {
            Destroy(gameObject);
        }

       /* if (main_coll.gameObject.name == "box(Clone)")
        {
            Debug.Log(main_coll.gameObject.name);
            if (collision.gameObject.name == "fisherman-boat(Clone)")
            {
                Debug.Log(collision.gameObject.name);
                transform.position = new Vector3(transform.position.x + 10f, transform.position.y, transform.position.z);
            }
        }*/
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (main_coll.gameObject.name == "box(Clone)")
        {
            if (collision.gameObject.name == "fisherman-boat(Clone)")
            {
                transform.position = new Vector3(transform.position.x + 10f, transform.position.y, transform.position.z);
            }
        }
    }
}
