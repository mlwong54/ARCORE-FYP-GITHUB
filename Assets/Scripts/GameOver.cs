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
    void Start()
    {
        ManageListScore();
        DisplayScore();
    }

    void DisplayScore()
    {
        scoreDisplay.text = PlayerPrefs.GetInt("RoundScores").ToString();
    }

    void ManageListScore()
    {
        if(listScores.allScores.Count<10)
        {
            listScores.allScores.Add(PlayerPrefs.GetInt("RoundScores"));
        }
        else
        {
            listScores.allScores.Remove(0);
        }
    }

    public void Replay()
    {
        SceneManager.LoadScene(0);
    }

    public void viewLeaderboard()
    {
        SceneManager.LoadScene(3);
    }
}
