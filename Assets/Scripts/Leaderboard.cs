using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;
using UnityEngine.SceneManagement;

public class Leaderboard : MonoBehaviour
{
    List<SavingData> result = new List<SavingData>();
    public GameObject textBundle;
    public TextMeshProUGUI[] ts;
    private int i = 0;
    void Awake()
    {
        List<int> temp=new List<int>();
        //List<int> allScores = new List<int>(FileHandler.ReadFromJSON<int>("scoreboard.json"));
        result = FileHandler.FetchMarks("scoreboard.json");
        ts = textBundle.GetComponentsInChildren<TextMeshProUGUI>();
        for(int i=0;i<result.ToArray().Count();i++)
        {
            temp.Add(result[i].points);
        }
        //List<int> list1 = new List<int>(allScores);
        temp.Sort();
        temp.Reverse();
        foreach (TextMeshProUGUI child in ts)
        {
            child.text = temp[i].ToString();
            i++; 
        }
        //RemoveOutOfRange();
    }

    /*void RemoveOutOfRange()
    {
        /*if(scores.allScores.Count.Equals(9))
        {
            Debug.Log("detects 9th element!");
            scores.allScores.RemoveAt(8);
        }
    }*/
    public void Back()
    {
        SceneManager.LoadScene(1);
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
    }

}
