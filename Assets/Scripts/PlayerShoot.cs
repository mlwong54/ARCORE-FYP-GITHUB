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
    private AudioSource audioListener2;
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
            DestroyGun();
            InstantiateGun();
        }
        else
        {
            currentGun = 1;
            gunSwitcher = !gunSwitcher;
            DestroyGun();
            InstantiateGun();
        }
        PlaySwitchSound();
    }

    public void InstantiateGun()
    {
        Instantiate(gunsIHave[currentGun].weaponPrefab, GunSpawnPoint.transform.position, GunSpawnPoint.transform.rotation, GunSpawnPoint.transform);
    }

    public void DestroyGun()
    {
        Destroy(GunSpawnPoint.transform.GetChild(0).gameObject);
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
            Reload(); }
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
        audioListener.clip = gunsIHave[currentGun].Empty;
        audioListener.Play();
    }
    void PlayReloadSound()
    {
        audioListener.clip = gunsIHave[currentGun].Reload;
        audioListener.Play();
    }
    void PlayFireSound()
    {
        audioListener.clip = gunsIHave[currentGun].Fire;
        audioListener.Play();
    }
    
    void PlaySwitchSound()
    {
        audioListener.clip = switchGun;
        audioListener.Play();
    }

    public void PlayPainSound()
    {
        audioListener2.clip = pain;
        audioListener2.Play();
    }

    public void PlayBonusSound()
    {
        audioListener2.clip = Bonus;
        audioListener2.Play();
    }
}
