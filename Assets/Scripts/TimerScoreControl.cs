using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using GameSystem.Events;

public class TimerScoreControl : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI timerUI;
    [SerializeField]
    private TextMeshProUGUI scoreUI;
    [SerializeField]
    private List<GameObject> enemyObject;

    public GameObject spawnAtLocationObject;

    private Queue<GameObject> spawnQueue = new Queue<GameObject>();

    public static TimerScoreControl Instance { get; private set; }

    [SerializeField]
    private VoidEvent DeathEvent;
    [SerializeField]
    private FloatValue timer;
    [SerializeField]
    private IntegerValue thisRoundScore;
    private int scores;

    public void Awake()
    {
        scores = 0;
        SaveScore();
        Instance = this;
    }

    public GameObject GetSpawnObject()
    {
        if(spawnQueue.Count == 0)
        {
            AddSpawns(20);
        }
        return spawnQueue.Dequeue();
    }

    private void AddSpawns(int count)
    {
        for(int i = 0; i <count;i++)
        {
            GameObject spawned = Instantiate(enemyObject[Random.Range(0, enemyObject.Count)], new Vector3(0, 1, 0), Quaternion.identity, spawnAtLocationObject.transform);
            spawned.SetActive(false);
            spawnQueue.Enqueue(spawned);
        }
    }

    public void ReturnToPool(GameObject spawned)
    {
        spawned.SetActive(false);
        spawnQueue.Enqueue(spawned);
    }


    public void SaveScore()
    {
        thisRoundScore.runtimeValue = scores;
        PlayerPrefs.SetInt("RoundScores", thisRoundScore.runtimeValue);
    }

    private void Start()
    {
        DisplayScore();
        StartCoroutine(SpawnWaiting(5));
    }

    IEnumerator SpawnUnitInIntervals(int interval)
    {
        while (true)
        {
            //Spawn a Unit Here
            var enemy = GetSpawnObject();
            enemy.transform.position = new Vector3(Random.Range(0,10),1 , Random.Range(0, 10));
            enemy.SetActive(true);
            //And now we wait
            yield return new WaitForSeconds(interval);
        }
    }

    IEnumerator SpawnWaiting(int interval)
    {
        yield return new WaitForSeconds(interval);
        StartCoroutine(SpawnUnitInIntervals(2));
    }
    public void UpdateScore()
    {
        scores= scores +10;
        DisplayScore();
    }

    public void DisplayScore()
    {
        scoreUI.text = scores.ToString();
        SaveScore();
    }

    public void Update()
    {
        if (timer.runtimeValue > 0)
        {
            timer.runtimeValue -= Time.deltaTime;

            float minutes = Mathf.FloorToInt(timer.runtimeValue / 60);
            float seconds = Mathf.FloorToInt(timer.runtimeValue % 60);

            timerUI.text = string.Format("{0:00}:{1:00}", minutes, seconds);

            if (timer.runtimeValue <= 0)
            {
                SaveScore();
                DeathEvent.Raise();
            }

            return;
        }
    }

}
