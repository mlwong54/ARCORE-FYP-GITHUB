using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public TextMeshProUGUI scoreDisplay;
    [SerializeField]
    private LeaderboardScores listScores;

    // Start is called before the first frame update
    void Awake()
    {
        ManageListScore();
        DisplayScore();
    }

    void DisplayScore()
    {
        scoreDisplay.text = PlayerPrefs.GetInt("RoundScores").ToString();
    }

    public void ManageListScore()
    {
        int newscore=PlayerPrefs.GetInt("RoundScores");
        listScores.allScores.Add(newscore);
        Debug.Log("added Leaderboard score!");
    }

    public void Replay()
    {
        SceneManager.LoadScene(1);
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
    }

    public void viewLeaderboard()
    {
        SceneManager.LoadScene(4);
    }
}
