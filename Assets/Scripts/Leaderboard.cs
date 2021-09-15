using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Leaderboard : MonoBehaviour
{
    [SerializeField]
    private LeaderboardScores scores;
    public GameObject textBundle;
    public TextMeshProUGUI[] ts;
    private int i = 0;
    void Start()
    {
        ts = textBundle.GetComponentsInChildren<TextMeshProUGUI>();
        foreach (TextMeshProUGUI child in ts)
        {
            child.text = (scores.allScores[i]).ToString();
            i++;
        }
    }

    public void Back()
    {
        SceneManager.LoadScene(0);
    }
    
}
