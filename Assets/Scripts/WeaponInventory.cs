using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "WeaponInventory", menuName = "Scriptable Objects/Inventory", order = 1)]
public class WeaponInventory : ScriptableObject
{
    public WeaponDescription primaryWeapon;
    public WeaponDescription secondaryWeapon;
}
