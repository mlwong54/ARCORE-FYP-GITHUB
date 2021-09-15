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
    // Update is called once per frame
    public void Start()
    {
        bullet = data.enemyWeapon;
        StartCoroutine(SpawnInterval());
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
