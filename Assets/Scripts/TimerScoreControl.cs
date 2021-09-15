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
            Instantiate(enemyObject[Random.Range(0, enemyObject.Count)], new Vector3(Random.Range(-10,10), 1, Random.Range(-10, 10)), Quaternion.identity, spawnAtLocationObject.transform);
            //And now we wait
            yield return new WaitForSeconds(interval);
        }
    }

    IEnumerator SpawnWaiting(int interval)
    {
        yield return new WaitForSeconds(interval);
        Debug.Log("Waiting finished!");
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
