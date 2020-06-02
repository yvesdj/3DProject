using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    private AudioSource _audioSource;
    private Animator _animator;
    private RecoilHandler _recoilHandler;

    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 10f;

    public float impactForce = 100f;

    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;

    public LineRenderer bulletTrail;

    private float nextTimeToFire = 0f;

    private void Awake()
    {
        _recoilHandler = fpsCam.GetComponent<RecoilHandler>();
    }

    void Start()
    {
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        _animator.SetBool("isFiring", false);
        CheckInput();
    }

    private void CheckInput()
    {
        if (!PauseMenu.gameIsPaused)
        {
            if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
            {
                nextTimeToFire = Time.time + 1f / fireRate;
                Shoot();
            }
        }
        
    }

    private void Shoot()
    {
        muzzleFlash.Play();
        _audioSource.Play();

        _recoilHandler.SetRecoil();

        _animator.SetBool("isFiring", true);

        CheckHit();
    }

    private void CheckHit()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            IHealthHandler target = hit.transform.GetComponent<IHealthHandler>();

            if (target != null)
            {
                target.TakeDamage(damage);
            }

            //if rigidbody with fysics
            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce( -hit.normal * impactForce); 
            }

            CreateBulletTrail(hit);

            CreateImpact(hit);
        }
    }

    private void CreateImpact(RaycastHit hit)
    {
        GameObject impact = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impact, 2f);
    }

    private void CreateBulletTrail(RaycastHit hit)
    {
        GameObject bulletTrailEffect = Instantiate(bulletTrail.gameObject, muzzleFlash.transform.localPosition, Quaternion.identity);

        LineRenderer lineRenderer = bulletTrailEffect.GetComponent<LineRenderer>();

        lineRenderer.SetPosition(0, muzzleFlash.transform.position);
        if (hit.point != null)
        {
            lineRenderer.SetPosition(1, hit.point);
        } else
        {
            //Render when shooting at nothing
            //lineRenderer.SetPosition(1, );
        }

        Destroy(bulletTrailEffect, 1f);
    }
}
