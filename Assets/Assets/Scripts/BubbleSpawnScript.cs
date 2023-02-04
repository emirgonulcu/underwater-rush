using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleSpawnScript : MonoBehaviour
{
    public GameObject Bubble;

    public Sprite[] BubbleSprites;

    SpriteRenderer Sprites;

    float bubble_time;

    private void Start()
    {
        bubble_time = Random.Range(0.7f, 2f);
        StartCoroutine(SpawnMoss(bubble_time));
    }

    public IEnumerator SpawnMoss(float time)
    {
        while (true)
        {
            int i = Random.Range(0, BubbleSprites.Length);
            Sprites = Bubble.GetComponent<SpriteRenderer>();
            Sprites.sprite = BubbleSprites[i];
            Instantiate(Bubble, new Vector3(Random.Range(-9f, 9f), Random.Range(-0.5f, -5f), 0), Quaternion.identity);
            yield return new WaitForSeconds(time);
        }
    }
}
