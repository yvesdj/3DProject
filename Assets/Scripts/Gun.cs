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

    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 10f;

    public float impactForce = 100f;

    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;

    public LineRenderer bulletTrail;

    private float nextTimeToFire = 0f;


    //Part of Pickups, should move
    //public bool IsEnhanced { get; set; }
    //public float effectDuration;
    //private float _originalFireRate;


    private void Awake()
    {
        _recoilHandler = fpsCam.GetComponent<RecoilHandler>();
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
        _playerInput = GetComponentInParent<PlayerInput>();


        //IsEnhanced = false;
        //_originalFireRate = fireRate;
    }

    // Update is called once per frame
    void Update()
    {
        _animator.SetBool("isFiring", false);
        CheckInput();

        //if (IsEnhanced == true)
        //{
        //    StartCoroutine(ReturnToNormalAfterTime());
        //}
    }

    //IEnumerator ReturnToNormalAfterTime()
    //{
    //    yield return new WaitForSeconds(effectDuration);

    //    IsEnhanced = false;
    //    fireRate = _originalFireRate;
    //}

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

        _recoilHandler.SetRecoil();

        _animator.SetBool("isFiring", true);

        CheckHit();
    }

    private void CheckHit()
    {
        RaycastHit hit;
        if (Physics.Raycast(muzzleFlash.transform.position, fpsCam.transform.forward, out hit, range))
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
