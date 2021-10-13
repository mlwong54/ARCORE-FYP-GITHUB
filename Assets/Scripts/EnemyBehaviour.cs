﻿using UnityEngine;
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

    private void OnDisable()
    {
        currentHP = data.enemyHealth;
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
            ownShoot.enabled = false;
            updateScore();
            TimerScoreControl.Instance.ReturnToPool(gameObject);
            this.enabled = false;
        }
    }

    public void updateScore()
    {
        AddScore.Raise();
    }
}
