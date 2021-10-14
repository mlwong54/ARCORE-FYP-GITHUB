using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;

public class Testing : MonoBehaviour
{
    [SerializeField] string filename;
    [SerializeField] private TextMeshProUGUI directory;
    [SerializeField] private TextMeshProUGUI firstResult;
    [SerializeField] private TextMeshProUGUI concaString;
    private string _concaString;

    List<SavingData> entries = new List<SavingData>();
    List<SavingData> result = new List<SavingData>();

    private void Start()
    {
        entries = FileHandler.ReadFromJSON<SavingData>(filename);
    }

    public void AddScores(int newscore)
    {
        _concaString = "";
        directory.text = FileHandler.GetPath(filename);
        entries.Add(new SavingData(newscore));
        FileHandler.SaveToJSON<SavingData>(entries, filename);
        result = FileHandler.FetchMarks(filename);

        for(int i = 0; i < result.ToArray().Count(); i++)
        {
            _concaString += result[i].points;
        }
        Debug.Log("Returned value 0" + result[0].points);
        Debug.Log("Returned value 0" + _concaString);
        firstResult.text = result[0].points.ToString();
        concaString.text = _concaString.ToString();
        //List<int> allScores = new List<int>(FileHandler.ReadFromJSON<int>("scoreboard.json"));
        //Debug.Log();
    }

}
