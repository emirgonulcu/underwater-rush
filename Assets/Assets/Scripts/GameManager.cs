using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using GoogleMobileAds.Api;

public class GameManager : MonoBehaviour
{
    private float score;

    public FishScript fish_sc;

    [SerializeField] AdManager ad_manager;

    [SerializeField] Image tutorial_image_1;
    [SerializeField] Text tutorial_text;

    [SerializeField] bool IsTutorialScene;

    int tutorial_count = 0;
    int ads_count = 0;
    int showAd = 0;

    [SerializeField] GameObject PauseButton;
    public GameObject PauseMenuObject;

    [SerializeField] Text scoreText;
    [SerializeField] TextMeshProUGUI highscoreText;

    bool DoOnce = false;

    private void Start()
    {
        if (IsTutorialScene)
        {
            Time.timeScale = 0f;
        }
        ads_count = PlayerPrefs.GetInt("AdsCount", 0);
        showAd = PlayerPrefs.GetInt("ShowAdCount", 0);
        Debug.Log("ads count: " + ads_count);
        Debug.Log("showadcount: " + showAd);
        DoOnce = false;
        UpdateHighScore();
    }

    void FixedUpdate()
    {
        if (!fish_sc.IsDead)
        {
            score += Time.deltaTime * 10f;
            scoreText.text = ((int)score).ToString();
            CheckHighScore();
        }
        else if (fish_sc.IsDead && DoOnce == false)
        {
            DoOnce = true;
            UpdateHighScore();
            if (ads_count == showAd)
            {
                ad_manager.ShowAd();
                ads_count += 1;
                showAd += 3;
                PlayerPrefs.SetInt("AdsCount", ads_count);
                PlayerPrefs.SetInt("ShowAdCount", showAd);
            }
            else
            {
                ads_count += 1;
                PlayerPrefs.SetInt("AdsCount", ads_count);
            }
        }

    }

    private void Update()
    {
        if (tutorial_count == 1)
        {
            tutorial_image_1.gameObject.SetActive(false);
            tutorial_text.gameObject.SetActive(true);
        }
        if (tutorial_count == 2)
        {
            SceneManager.LoadScene("MainMenuScene");
        }
    }

    public void NextTutorial()
    {
        tutorial_count += 1;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("LevelScene");
        Time.timeScale = 1.0f;
    }

    public void PauseMenu()
    {
        Time.timeScale = 0f;
        PauseMenuObject.SetActive(true);
        PauseButton.SetActive(false);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        PauseMenuObject.SetActive(false);
        PauseButton.SetActive(true);
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenuScene");
    }

    void CheckHighScore()
    {
        if ((int)score > PlayerPrefs.GetInt("HighScore",  0))
        {
            PlayerPrefs.SetInt("HighScore", (int)score);
        }
    }

    void UpdateHighScore()
    {
        highscoreText.text = $"{PlayerPrefs.GetInt("HighScore", 0)}";
    }
}
