using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageReceiver : MonoBehaviour
{
    [SerializeField]
    private HPControl health;
    
    public void SendDamage(float damage)
    {
        health.Damage(damage);
    }
}
