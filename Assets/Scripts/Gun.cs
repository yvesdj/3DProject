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
    private PlayerInput _playerInput;
    private LayerMask _layerMask;

    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 10f;
    public float sideRecoilForce = 0.25f;
    public float upwardsRecoilForce = 1f;

    public float impactForce = 100f;

    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;

    public LineRenderer bulletTrail;

    private float nextTimeToFire = 0f;

    private void Awake()
    {
        _recoilHandler = fpsCam.GetComponent<RecoilHandler>();
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
        _playerInput = GetComponentInParent<PlayerInput>();
        _layerMask = ~LayerMask.GetMask("Invisible");
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
            if (_playerInput.IsFiring && Time.time >= nextTimeToFire)
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

        _recoilHandler.SetRecoil(upwardsRecoilForce, sideRecoilForce);

        _animator.SetBool("isFiring", true);

        CheckHit();
    }

    private void CheckHit()
    {
        RaycastHit hit;
        if (Physics.Raycast(muzzleFlash.transform.position, fpsCam.transform.forward, out hit, range, _layerMask))
        {
            Debug.Log(hit.transform.name);

            IHealthHandler targetHealth = hit.transform.GetComponent<IHealthHandler>();
            DialogueTrigger dialogueTrigger = hit.transform.GetComponent<DialogueTrigger>();

            if (targetHealth != null)
            {
                targetHealth.TakeDamage(damage);
            }

            if (dialogueTrigger != null && dialogueTrigger.shootable)
            {
                dialogueTrigger.TriggerDialogue();
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
