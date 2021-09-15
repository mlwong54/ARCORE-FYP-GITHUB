using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ListScores", menuName = "Legacy Scriptable Objects/ListScores", order = 1)]
public class LeaderboardScores : ScriptableObject
{
    public List<int> allScores;
}
