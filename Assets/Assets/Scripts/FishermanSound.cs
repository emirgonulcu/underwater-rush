using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishermanSound : MonoBehaviour
{
    [SerializeField]
    AudioSource main_audio;

    public AudioClip[] fisherman_move_around_clips;

    public float clip_time = 4f;

    public bool CanSing = false;

    /*void Start()
    {
        StartCoroutine(MoveAroundClipChanges());
    }

    IEnumerator MoveAroundClipChanges()
    {
        while (CanSing)
        {
            int i = Random.Range(0, fisherman_move_around_clips.Length);
            main_audio.clip = fisherman_move_around_clips[i];
            main_audio.Play();
            yield return new WaitForSeconds(clip_time);
        }
    }*/

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "FishermanSinging")
        {
            CanSing = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "FishermanSinging")
        {
            CanSing = false;
        }
    }

}
