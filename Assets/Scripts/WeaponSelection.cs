using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WeaponSelection : MonoBehaviour
{
    public List<WeaponDescription> weaponsAvailable;
    public WeaponInventory gunList;

    public void SelectFirstWeapon(int num)
    {
        gunList.primaryWeapon =weaponsAvailable[num];
    }

    public void SelectSecondWeapon(int num)
    {
        gunList.secondaryWeapon = weaponsAvailable[num];
    }

}
