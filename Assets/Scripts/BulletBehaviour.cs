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


	[Tooltip("Prefab of wall damange hit. The object needs 'LevelPart' tag to create decal on it.")]
	public GameObject decalHitWall;
	[Tooltip("Decal will need to be sligtly infront of the wall so it doesnt cause rendeing problems so for best feel put from 0.01-0.1.")]
	public float floatInfrontOfWall;
	[Tooltip("Blood prefab particle this bullet will create upoon hitting enemy")]
	public GameObject muzzleEffect;
	[Tooltip("Put Weapon layer and Player layer to ignore bullet raycast.")]
	public LayerMask ignoreLayer;

	void Update()
	{
		Debug.DrawRay(transform.position, transform.forward, Color.green);
		if (Physics.Raycast(transform.position, transform.forward, out hit, maxDistance, ~ignoreLayer))
		{

				/*if (hit.transform.tag == "Box")
				{
					Instantiate(decalHitWall, hit.point + hit.normal * floatInfrontOfWall, Quaternion.LookRotation(hit.normal));
					Destroy(gameObject);
				}*/
				if (hit.transform.tag == "Enemy")
				{
					Debug.Log("hit enemy!");
					hit.transform.gameObject.GetComponent<EnemyBehaviour>().Damage(bulletDamage);
					//Instantiate(muzzleEffect, hit.point, Quaternion.LookRotation(hit.normal));
					Destroy(gameObject);
				}
				if(hit.transform.tag == "BonusHealth")
				{
					Debug.Log("Add health!");
					//Instantiate(muzzleEffect, hit.point, Quaternion.LookRotation(hit.normal));
					AddHealthEvent.Raise();
					PlayBonusSound.Raise();
					Destroy(hit.transform.gameObject);
					Destroy(gameObject);
				}
				if (hit.transform.tag == "BonusAmmo")
				{
					Debug.Log("Add ammo!");
					//Instantiate(muzzleEffect, hit.point, Quaternion.LookRotation(hit.normal));
					AddAmmoEvent.Raise();
					PlayBonusSound.Raise();
					Destroy(hit.transform.gameObject);
					Destroy(gameObject);
				}
		}
		Destroy(gameObject, 0.1f);
	}
}
