using UnityEngine;
using GameSystem.Events;

public class EnemyBehaviour : MonoBehaviour
{
    public LayerMask ignoreLayer;
    public EnemyData data;
    private float currentHP;
    public IntegerValue overallScores;
    public Transform PlayerTarget;
    public EnemyShoot ownShoot;

    public VoidEvent AddScore;

    private void Awake() {
        currentHP= data.enemyHealth;
        PlayerTarget = GameObject.FindWithTag("Player").GetComponent<Transform>();
        ownShoot = GetComponent<EnemyShoot>();
    }

    public void Damage(float damageValue)
    {
        currentHP= currentHP - damageValue;
        Debug.Log(currentHP);
    }

    public void Update()
    {
        transform.LookAt(PlayerTarget);
        if (currentHP <= 0f)
        {
            updateScore();
            Destroy(gameObject);
        }
    }

    public void updateScore()
    {
        Debug.Log("Updated score!");
        AddScore.Raise();
    }
}
