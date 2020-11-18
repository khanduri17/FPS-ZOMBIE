using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPcamera;
    [SerializeField] float Range = 200f;
    [SerializeField] float Damage = 10;
    [SerializeField] ParticleSystem muzzleVFX;
    [SerializeField] GameObject hitEffect;
    [SerializeField] Ammo ammoslot;
    [SerializeField] float secondsBetweenShoot = 2f;
    [SerializeField] TextMeshProUGUI bulletText;
    [SerializeField] AmmmoType ammmotype;
    bool canShoot = true;

    private void OnEnable()
    {
        canShoot = true;
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && canShoot) 
            {
               StartCoroutine (Shoot());
            }
        DisplayBulletText();
        
    }

    private void DisplayBulletText()
    {
        int ammo = ammoslot.Currentammo(ammmotype);
        bulletText.text = " AMMO "+ammo.ToString();
    }

    IEnumerator Shoot()
    {
        canShoot = false;
        if (ammoslot.Currentammo(ammmotype) > 0)
        {
            PlayMuzzleFlash();
            ProcessRayCasting();
            ammoslot.reduceAmmo(ammmotype);
        }
        yield return new WaitForSeconds(secondsBetweenShoot);
        

        canShoot = true;
    }

    private void PlayMuzzleFlash()
    {
        muzzleVFX.Play();
    }

    private void ProcessRayCasting()
    {
        RaycastHit hitinfo;
        if (Physics.Raycast(transform.position, FPcamera.transform.forward, out hitinfo, Range))
        {
            CreateHitImpact(hitinfo);
            EnemyHealth target = hitinfo.transform.GetComponent<EnemyHealth>();
            if (target == null) { return; }
            target.TakeDamage(Damage);
        }
        else
        {
            return;
        }
}

    private void CreateHitImpact(RaycastHit hitinfo)
    {
       GameObject effect= Instantiate(hitEffect, hitinfo.point,Quaternion.LookRotation(hitinfo.normal));
       Destroy(effect, 0.1f);
    }
}
