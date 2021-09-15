using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "Scriptable Objects/EnemyData", order = 1)]
public class EnemyData : ScriptableObject
{
    public GameObject enemyWeapon;
    public float enemyHealth;
    public int enemyScore;
}
