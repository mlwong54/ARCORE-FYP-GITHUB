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
        List<int> list1 = new List<int>(scores.allScores);
        list1.Sort();
        list1.Reverse();
        foreach (TextMeshProUGUI child in ts)
        {
            child.text = list1[i].ToString();
            scores.allScores[i]= list1[i];
            i++; 
        }
        RemoveOutOfRange();
    }

    void RemoveOutOfRange()
    {
        if(scores.allScores.Count.Equals(9))
        {
            Debug.Log("detects 9th element!");
            scores.allScores.RemoveAt(8);
        }
    }


    public void Back()
    {
        SceneManager.LoadScene(0);
    }
    
}
