using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameSystem.Events;

public class BulletBehaviour : MonoBehaviour
{
	[Tooltip("Furthest distance bullet will look for target")]
	[SerializeField]
	private float maxDistance = 1000000;
	[SerializeField]
	private float bulletDamage;
	RaycastHit hit;
	[SerializeField]
	private VoidEvent AddHealthEvent;
	[SerializeField]
	private VoidEvent AddAmmoEvent;
	[SerializeField]
	private VoidEvent PlayBonusSound;

	[Tooltip("Blood prefab particle this bullet will create upoon hitting enemy")]
	public GameObject muzzleEffect;
	[Tooltip("Put Weapon layer and Player layer to ignore bullet raycast.")]
	public LayerMask ignoreLayer;

	void Update()
	{
		Debug.DrawRay(transform.position, transform.forward, Color.green);
		if (Physics.Raycast(transform.position, transform.forward, out hit, maxDistance, ~ignoreLayer))
		{

				if (hit.transform.tag == "Enemy")
				{
					Debug.Log("hit enemy!");
					hit.transform.gameObject.GetComponent<EnemyBehaviour>().Damage(bulletDamage);	
					Destroy(gameObject);
				}
				if(hit.transform.tag == "BonusHealth")
				{
					AddHealthEvent.Raise();
					PlayBonusSound.Raise();
					TimerScoreControl.Instance.ReturnToPool(hit.transform.gameObject);
					Instantiate(muzzleEffect, hit.point, Quaternion.LookRotation(hit.normal));
					Destroy(gameObject);
				}
				if (hit.transform.tag == "BonusAmmo")
				{
					
					AddAmmoEvent.Raise();
					PlayBonusSound.Raise();
					TimerScoreControl.Instance.ReturnToPool(hit.transform.gameObject);
					Instantiate(muzzleEffect, hit.point, Quaternion.LookRotation(hit.normal));
					Destroy(gameObject);
				}
		}
		Destroy(gameObject, 0.1f);
	}
}
