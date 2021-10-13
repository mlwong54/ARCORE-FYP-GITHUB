using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField]
    private GameObject BulletSpawnPoint;
    [SerializeField]
    private GameObject GunSpawnPoint;
    [SerializeField]
    private TextMeshProUGUI bulletCount;
    [SerializeField]
    private TextMeshProUGUI bulletMagazine;
    [SerializeField]
    private WeaponInventory gunsInventory;
    [SerializeField]
    private AudioSource audioListener;
    [SerializeField]
    private AudioClip switchGun;
    [SerializeField]
    private AudioClip pain;
    [SerializeField]
    private AudioClip Bonus;

    public List<WeaponDescription> gunsIHave;

    private bool gunSwitcher = false;
    private int currentGun = 0;

    public void Start()
    {
        gunsIHave.Add(gunsInventory.primaryWeapon);
        gunsIHave.Add(gunsInventory.secondaryWeapon);
        InstantiateGun();
        SwitchGunInventory();
    }

    public void SwitchGunInventory()
    {
        if (!gunSwitcher)
        {
            currentGun = 0;
            gunSwitcher = !gunSwitcher;
            ToNextGun(1);
        }
        else
        {
            currentGun = 1;
            gunSwitcher = !gunSwitcher;
            ToNextGun(0);
        }
        PlaySwitchSound();
    }

    public void InstantiateGun()
    {
        for(int i= 0; i<2; i++)
        {
            var gun=Instantiate(gunsIHave[i].weaponPrefab, GunSpawnPoint.transform.position, GunSpawnPoint.transform.rotation, GunSpawnPoint.transform);
            if(i==0)
            {
                gun.SetActive(true);
            }
            else
            {
                gun.SetActive(false);
            }
        }
    }

    public void ToNextGun(int num)
    {
        GunSpawnPoint.transform.GetChild(num).gameObject.SetActive(false);
        GunSpawnPoint.transform.GetChild(currentGun).gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        bulletCount.text = gunsIHave[currentGun].runtimeAmmo.ToString();
        bulletMagazine.text = gunsIHave[currentGun].runtimeMagazine.ToString();
    }

    public void Shoot()
    {
        if (gunsIHave[currentGun].runtimeAmmo > 0)
        {
            Instantiate(gunsIHave[currentGun].weaponBullet, BulletSpawnPoint.transform.position, BulletSpawnPoint.transform.rotation);
            PlayFireSound();
        }
        gunsIHave[currentGun].runtimeAmmo -= 1;
        if (gunsIHave[currentGun].runtimeAmmo == 0 && gunsIHave[currentGun].runtimeMagazine != 0)
        {
            PlayEmptySound();
            Reload(); 
        }
    }

    public void Reload()
    {
        int difference = gunsIHave[currentGun].GunAmmo - gunsIHave[currentGun].runtimeAmmo;

        if (difference == 0 && gunsIHave[currentGun].runtimeMagazine != 0)
        {
            PlayEmptySound();
            return;
        }
        else if (difference > 0 && gunsIHave[currentGun].runtimeMagazine != 0)
        {
            if (gunsIHave[currentGun].runtimeMagazine >= gunsIHave[currentGun].GunAmmo)
            {
                gunsIHave[currentGun].runtimeAmmo += difference;
                gunsIHave[currentGun].runtimeMagazine -= difference;
            }
            else if (gunsIHave[currentGun].runtimeMagazine < gunsIHave[currentGun].GunAmmo)
            {
                 gunsIHave[currentGun].runtimeAmmo += difference;
                 if ((gunsIHave[currentGun].runtimeMagazine -= difference) <= 0)
                 {
                     gunsIHave[currentGun].runtimeMagazine = 0;
                 }
                 else
                 {
                     gunsIHave[currentGun].runtimeMagazine -= difference;
                 }
            }
            PlayReloadSound();
        }
    }

    public void AddAmmo()
    {
        gunsIHave[currentGun].runtimeMagazine += 50;
    }

    void PlayEmptySound()
    {
        audioListener.PlayOneShot(gunsIHave[currentGun].Empty);
    }
    void PlayReloadSound()
    {
        audioListener.PlayOneShot(gunsIHave[currentGun].Reload);
    }
    void PlayFireSound()
    {
        audioListener.clip = gunsIHave[currentGun].Fire;
        audioListener.Play();
    }
    
    void PlaySwitchSound()
    {
        audioListener.PlayOneShot(switchGun);
    }

    public void PlayPainSound()
    {
        audioListener.PlayOneShot(pain);
    }

    public void PlayBonusSound()
    {
        audioListener.PlayOneShot(Bonus);
    }
}
