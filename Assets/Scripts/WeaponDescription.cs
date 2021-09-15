using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "WeaponDescription", menuName = "Scriptable Objects/WeaponDescription", order = 1)]
public class WeaponDescription : ScriptableObject, ISerializationCallbackReceiver
{
    public GameObject weaponPrefab;
    public string weaponName;
    public string description;

    public enum Type {Rifle, Sniper, Pistol, Glock};

    public Type WeaponType;
    public GameObject weaponBullet;
    public int GunMagazine;
    public int GunAmmo;

    public AudioClip Fire;
    public AudioClip Empty;
    public AudioClip Reload;


    [NonSerialized]
    public int runtimeMagazine;
    [NonSerialized]
    public int runtimeAmmo;

    public void OnAfterDeserialize()
    {
        runtimeMagazine = GunMagazine;
        runtimeAmmo = GunAmmo;
    }

    public void OnBeforeSerialize() { }

}
