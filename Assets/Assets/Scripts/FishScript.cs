using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements.Experimental;

public class FishScript : MonoBehaviour
{
    private Rigidbody2D rb;

    private Animator animator;

    [SerializeField] 
    GameObject fish_eyeball;
    [SerializeField]
    GameObject RestartMenu;

    [SerializeField]
    AudioSource AudioManager;

    [SerializeField]
    FishermanSound Fisherman;

    private AudioSource main_audio_source;
    private AudioClip splash_sound;

    private float jump_velocity = 5.0f;

    private bool IsJumping = false;
    private bool CanMove = true;
    private bool IsOnBorder = false;
    private bool CanHighJumping = false;
    private bool IsPlayedSound = false;

    public bool IsDead = false;


    public AudioClip[] fisherman_escape_clips;
    public AudioClip[] fisherman_catch_clips;
    public AudioClip fisherman_surprise_clip;
    public AudioClip fisherman_sight_clip;

    void Start()
    {
        rb= GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        main_audio_source = GetComponent<AudioSource>();

        StartCoroutine(MoveAroundClipChanges(Fisherman.clip_time));

        RestartMenu.gameObject.SetActive(false);
    }

    
    void Update()
    {
        if (!IsDead)
        {
            DeathControl();

            if (!IsJumping)
            {
                if (Input.touchCount > 0 && CanMove)
                {
                    Touch touch = Input.GetTouch(0);

                    if (touch.phase == TouchPhase.Began)
                    {
                        rb.velocity = Vector2.up * jump_velocity;
                        CanMove = false;
                        transform.rotation = Quaternion.Euler(0, 0, 35f);
                        animator.SetBool("IsFlying", true);
                    }
                }
                else
                {
                    animator.SetBool("IsFlying", false);
                }
            }
            if (rb.velocity.y < 0 && !IsOnBorder)
            {
                CanMove = true;
                transform.rotation = Quaternion.Euler(0, 0, -35f);
            }
            if (rb.velocity.y < 0)
            {
                transform.rotation = Quaternion.Euler(0, 0, -35f);
            }
        }
    }

    IEnumerator MoveAroundClipChanges(float time)
    {
        while (Fisherman.CanSing && !IsPlayedSound)
        {
            int i = Random.Range(0, Fisherman.fisherman_move_around_clips.Length);
            AudioManager.clip = Fisherman.fisherman_move_around_clips[i];
            AudioManager.Play();
            yield return new WaitForSeconds(time);
        }
    }

    public void ButtonJumping()
    {
        if (IsJumping == false && CanHighJumping)
        {
            rb.velocity = Vector2.up * (jump_velocity + 5f);
            transform.rotation = Quaternion.Euler(0, 0, 35f);
            animator.SetBool("IsFlying", true);
            IsJumping = true;
        }
    }

    void DeathControl()
    {
        if (IsDead)
        {
            Time.timeScale = 0.4f;
            animator.SetBool("Death", true);
            fish_eyeball.gameObject.SetActive(false);
            RestartMenu.gameObject.SetActive(true);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Death")
        {
            IsDead = true;
            DeathControl();
        }

        if (collision.gameObject.tag == "Jumping")
        {
            CanHighJumping = true;
            CanMove = false;
            IsOnBorder = true;
        }

        if (collision.gameObject.tag == "SplashSound" && rb.velocity.y < 0)
        {
            main_audio_source.Play();
        }

        if (collision.gameObject.tag == "EscapeFish" && !IsPlayedSound)
        {
            IsPlayedSound = true;
            int i = Random.Range(0, fisherman_escape_clips.Length);
            AudioManager.Stop();
            AudioManager.clip = fisherman_escape_clips[i];
            AudioManager.Play();
        }
        if (collision.gameObject.tag == "StopSound" && IsPlayedSound)
        {
            IsPlayedSound = false;
        }
        if (collision.gameObject.tag == "SightAndSound" && !IsPlayedSound)
        {
            IsPlayedSound = true;
            AudioManager.Stop();
            AudioManager.clip = fisherman_sight_clip;
            AudioManager.Play();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Jumping")
        {
            CanHighJumping = true;
            CanMove = false;
            IsOnBorder = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Jumping")
        {
            if (IsJumping == true && rb.velocity.y < 0)
            {
                IsJumping = false;
                CanMove = true;
                IsOnBorder = false;
                CanHighJumping = false;
            }
            else if (IsJumping == false)
            {
                CanMove = true;
                IsOnBorder = false;
                CanHighJumping = false;
            }
        }

        if (collision.gameObject.tag == "SightAndSound" && IsPlayedSound)
        {
            IsPlayedSound = false;
        }
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Death")
        {
            if (collision.gameObject.name == "fisherman-hook")
            {
                if (!IsPlayedSound)
                {
                    int i = Random.Range(0, fisherman_catch_clips.Length);
                    AudioManager.Stop();
                    AudioManager.clip = fisherman_catch_clips[i];
                    AudioManager.Play();
                }
            }
            IsDead = true;
            DeathControl();
        }
        if (collision.gameObject.tag == "Fisherman" && !IsPlayedSound)
        {
            IsPlayedSound = true;
            AudioManager.Stop();
            AudioManager.clip = fisherman_surprise_clip;
            AudioManager.Play();
        }
    }
}
