using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    private Animator animator;

    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 15f;

    public float impactForce = 30f;

    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;

    private float nextTimeToFire = 0f;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }

        animator.SetBool("isFiring", false);
    }

    private void Shoot()
    {
        muzzleFlash.Play();

        animator.SetBool("isFiring", true);

        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            Target target =  hit.transform.GetComponent<Target>();

            if (target != null)
            {
                target.TakeDamage(damage);
            }

            //phisic
            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(hit.normal * impactForce);
            }

            GameObject impact = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impact, 2f);
        }

    }

    //private void GunAnimation()
    //{
    //    //gameObject where script is attached to
    //    for (int i = 0; i < length; i++)
    //    {

    //    }
    //    gameObject.transform.localRotation = Quaternion.Euler(-4f, 0f, 0f);
    //}
}
