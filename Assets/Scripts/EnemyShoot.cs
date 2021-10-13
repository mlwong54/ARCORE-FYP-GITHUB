using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField]
    private EnemyData data;
    private GameObject bullet;
    [SerializeField]
    private AudioSource shootingSound;

    public void Start()
    {
        bullet = data.enemyWeapon;
        DoStuff();
    }
    public void onEnable()
    {
        DoStuff();
    }

    void DoStuff()
    {
        StartCoroutine(SpawnInterval());
        Debug.Log("Start shoot");
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }
    IEnumerator SpawnInterval()
    {
        while(true)
        {
            yield return new WaitForSeconds(1);
            Instantiate(bullet, transform.position, transform.rotation);
            shootingSound.Play();
        }
    }
}
