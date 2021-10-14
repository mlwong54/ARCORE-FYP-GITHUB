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
    public GameObject explosionEffect;

    public VoidEvent AddScore;

    private void Awake() {
        currentHP = data.enemyHealth;
        PlayerTarget = GameObject.FindWithTag("Player").GetComponent<Transform>();
        ownShoot = GetComponent<EnemyShoot>();
    }

    private void OnEnable()
    {
        currentHP = data.enemyHealth;
        Debug.Log("Restore HP" + currentHP);
    }

    public void Damage(float damageValue)
    {
        currentHP= currentHP - damageValue;
    }

    public void Update()
    {
        transform.LookAt(PlayerTarget);
        if (currentHP <= 0f)
        {
            Instantiate(explosionEffect, transform.position, transform.rotation);
            updateScore();
            TimerScoreControl.Instance.ReturnToPool(gameObject);
        }
    }

    public void updateScore()
    {
        AddScore.Raise();
    }
}
