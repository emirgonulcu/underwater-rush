using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public FishScript fish_sc;

    public GameObject Waves;
    public GameObject Box;
    public GameObject[] SelectedFlow;
    public GameObject Rock;
    public GameObject Moss;
    public GameObject Fisherman;

    float wave_time = 1.5f;
    float box_time;
    float flow_time;
    float rock_time;
    float moss_time;
    float fisherman_time;



    private void Awake()
    {
        box_time = Random.Range(8f, 16f);
        flow_time = Random.Range(1f, 3f);
        rock_time = Random.Range(18f, 25f);
        moss_time = Random.Range(3f, 5f);
        fisherman_time = Random.Range(30f, 40f);
    }

    private void Start()
    {
        StartCoroutine(SpawnWaves(wave_time));
        StartCoroutine(SpawnBoxs(box_time));
        StartCoroutine(SpawnFlows(flow_time));
        StartCoroutine(SpawnRocks(rock_time));
        StartCoroutine(SpawnMoss(moss_time));
        StartCoroutine(SpawnFisherman(fisherman_time));
    }


    public IEnumerator SpawnWaves(float time)
    {
        while (!fish_sc.IsDead)
        {
            Instantiate(Waves, new Vector3(Random.Range(14f, 16f), 1.74f, 0), Quaternion.identity);
            yield return new WaitForSeconds(time);
        }
    }

    public IEnumerator SpawnBoxs(float time)
    {
        while (!fish_sc.IsDead)
        {
            Instantiate(Box, new Vector3(Random.Range(15f, 30f), 2.74f, 0), Quaternion.identity);
            yield return new WaitForSeconds(time);
        }
    }

    public IEnumerator SpawnFlows(float time)
    {
        while (!fish_sc.IsDead)
        {
            int i = Random.Range(0, 3);
            Instantiate(SelectedFlow[i], new Vector3(Random.Range(14f, 16f), Random.Range(-3.80f, 0), 0), Quaternion.identity);
            yield return new WaitForSeconds(time);
        }
    }

    public IEnumerator SpawnRocks(float time)
    {
        while (!fish_sc.IsDead)
        {
            Instantiate(Rock, new Vector3(Random.Range(13f, 35f), -5.7099f, 0),Quaternion.identity);
            yield return new WaitForSeconds(time);
        }
    }

    public IEnumerator SpawnMoss(float time)
    {
        while (!fish_sc.IsDead)
        {
            Instantiate(Moss, new Vector3(Random.Range(14f, 30f), -5.7099f, 0), Quaternion.identity);
            yield return new WaitForSeconds(time);
        }
    }

    public IEnumerator SpawnFisherman(float time)
    {
        while (!fish_sc.IsDead)
        {
            Instantiate(Fisherman, new Vector3(Random.Range(15f, 50f), 0.18f, 0), Quaternion.identity);
            yield return new WaitForSeconds(time);
        }
    }
}
