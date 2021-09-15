using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameSystem.Events;

public class EnemyBullet : MonoBehaviour
{
	private float maxDistance = 1000000;
	[SerializeField]
	private float bulletDamage;
	//public AudioSource sound;
//	public AudioClip shotSound;
	RaycastHit hit;
	public LayerMask ignoreLayer;
	private float HoriRandomShoot;
	private float VertiRandomShoot;
	public float HitAccuracy = 0.3f;
	public float speed;
	private Vector3 movingAngle;

	public VoidEvent playerHealth;
    

    private void Start()
    {
		//sound = GetComponent<AudioSource>();
		HoriRandomShoot = Random.Range(0.1f, 1.0f);
		VertiRandomShoot = Random.Range(0.0f, 0.5f);
		if (HoriRandomShoot > 1.0f - HitAccuracy)
		{
			HoriRandomShoot = 0.0f;
		}
		if(VertiRandomShoot > 0.5f - HitAccuracy)
        {
			VertiRandomShoot = 0.0f;
        }
		//sound.Play();
	}
    void Update()
	{
		movingAngle = transform.forward + new Vector3(HoriRandomShoot, VertiRandomShoot,0);
		transform.position += movingAngle * Time.deltaTime * speed;

		Debug.DrawRay(transform.position, movingAngle, Color.green);
		if (Physics.Raycast(transform.position, movingAngle, out hit, maxDistance, ~ignoreLayer))
		{
			if (hit.transform.tag == "Player")
			{
				Debug.Log("hit Player!");
				hit.transform.GetComponent<DamageReceiver>().SendDamage(bulletDamage);
				Destroy(gameObject);
			}
		}
		Destroy(gameObject, 2.0f);
	}
}
