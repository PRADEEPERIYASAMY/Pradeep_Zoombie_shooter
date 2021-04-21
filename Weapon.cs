using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera camera;
    [SerializeField] float range = 100f;
    [SerializeField] float damage = 50f;
    [SerializeField] ParticleSystem Gunfire;
    [SerializeField] AudioSource gunshoot;
    [SerializeField] GameObject hiteffect;
    [SerializeField] Ammo ammoSlot;
    [SerializeField] float timeBetweenShots = 0.2f;
    bool canShoot = true;
    [SerializeField] AmmoType ammoType;
    [SerializeField] TextMeshProUGUI ammoCount;
    [SerializeField] TextMeshProUGUI ammoKind;

 
    // Update is called once per frame
    void Update()
    {
        DisplayAmmo();
        if (Input.GetMouseButtonDown(0) && canShoot == true)
        {
            StartCoroutine(Shoot());
        }
        
    }

    private void DisplayAmmo()
    {
        int currentAmmo = ammoSlot.GetCurrentAmmo(ammoType);
        ammoCount.text = currentAmmo.ToString();
        ammoKind.text = ammoType.ToString();

    }

    private void OnEnable()
    {
        canShoot = true;
    }
    IEnumerator Shoot()
    {
        canShoot = false;
       if(ammoSlot.GetCurrentAmmo(ammoType) > 0)
        {

            ProcessRayCast();
            PlayAudio();
            PlayGunfire();
            ammoSlot.ReduceCurrentAmmo(ammoType);
        }
        yield return new WaitForSeconds(timeBetweenShots);
        canShoot = true;
    }

    private void PlayAudio()
    {
        gunshoot.Play();
    }

    private void PlayGunfire()
    {
        Gunfire.Play();
    }

    private void ProcessRayCast()
    {
        RaycastHit hit;
        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, range))
        {
            CreateHitImpact(hit);
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if (target == null) return;
            target.TakeDamage(damage);
        }
        else
        {
            return;
        }
    }

    private void CreateHitImpact(RaycastHit hit)
    {
     GameObject impact = Instantiate(hiteffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impact, .1f);
    }
}
