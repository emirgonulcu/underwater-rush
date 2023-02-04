using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSpawner : MonoBehaviour
{
    public GameObject[] SelectedFlow;

    float flow_time;

    private void Awake()
    {
        flow_time = Random.Range(1f, 3f);
    }

    private void Start()
    {
        StartCoroutine(SpawnFlows(flow_time));
        Time.timeScale = 1f;
    }

    public IEnumerator SpawnFlows(float time)
    {
        while (true)
        {
            int i = Random.Range(0, 3);
            Instantiate(SelectedFlow[i], new Vector3(Random.Range(14f, 16f), Random.Range(-3.80f, 0), 0), Quaternion.identity);
            yield return new WaitForSeconds(time);
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene("LevelScene");
        Time.timeScale = 1f;
    }

    public void ShowTutorial()
    {
        SceneManager.LoadScene("TutorialScene");
    }

    public void Instagram()
    {
        Application.OpenURL("https://www.instagram.com/barracagames");
    }

    public void Tiktok()
    {
        Application.OpenURL("https://www.tiktok.com/@barracagames");
    }

    public void Twitter()
    {
        Application.OpenURL("https://www.twitter.com/GamesBarraca");
    }
}
