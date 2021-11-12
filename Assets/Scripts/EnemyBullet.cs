using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameSystem.Events;

public class EnemyBullet : MonoBehaviour
{
	private float maxDistance = 1000000;
	[SerializeField]
	private float bulletDamage;
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
	}
    void Update()
	{
		movingAngle = transform.forward + new Vector3(HoriRandomShoot, VertiRandomShoot,0);
		transform.position += movingAngle * Time.deltaTime * speed;

		if (Physics.Raycast(transform.position, movingAngle, out hit, maxDistance, ~ignoreLayer))
		{
			if (hit.transform.tag == "Player")
			{
				hit.transform.GetComponent<DamageReceiver>().SendDamage(bulletDamage);
				Destroy(gameObject);
			}
		}
		Destroy(gameObject, 2.0f);
	}
}
