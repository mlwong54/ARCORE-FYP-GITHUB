using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameSystem.Events;

public class TouchBonus : MonoBehaviour
{
    public VoidEvent AddMoreScore;
    [SerializeField]
    private GameObject ownSound;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            Instantiate(ownSound, transform.position, Quaternion.LookRotation(transform.position));
            AddMoreScore.Raise();
            TimerScoreControl.Instance.ReturnToPool(gameObject);
        }
    }
}
