using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectShakeScript : MonoBehaviour
{
    float shake_speed = 1f; //how fast it shakes
    float amount = .3f; //how much it shakes
    float random_pos;

    private void Start()
    {
        if (gameObject.tag == "Wave")
        {
            random_pos = Random.Range(1.50f, 1.74f);
            shake_speed = 1f;
        }
        if (gameObject.tag == "Fisherman")
        {
            random_pos = Random.Range(0.06f, 0.08f);
            shake_speed = 2.5f;
            amount = .2f;
        }
        if (gameObject.tag == "Death")
        {
            random_pos = 2.70f;
            shake_speed = 1f;
        }
    }
    private void Update()
    {
        float transformY = transform.position.y;
        transformY = Mathf.Sin(Time.time * shake_speed) * amount + random_pos;
        transform.position = new Vector3(transform.position.x, transformY, transform.position.z);
    }
}
