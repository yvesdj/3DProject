using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGunHandler : MonoBehaviour
{
    public GameObject target;

    public ParticleSystem muzzleFlash;

    public float maxEngageRange;
    private bool isEngaging;

    public float fireRate = 5f;
    private float _nextTimeToFire = 0f;

    // Start is called before the first frame update
    void Start()
    {
        //target = Enemy
    }

    // Update is called once per frame
    void Update()
    {
        isEngaging = IsInRange();

        if (isEngaging)
        {
            transform.LookAt(target.transform);
            
            Shoot();
        }

    }

    private bool IsInRange()
    {
        if (Vector3.Distance(transform.position, target.transform.position) < maxEngageRange)
        {
            return true;
        } else
        {
            return false;
        }
    }

    private void Shoot()
    {
        if (Time.time >= _nextTimeToFire)
        {
            _nextTimeToFire = Time.time + 1f / fireRate;
            muzzleFlash.Play();
        }
        
        //_audioSource.Play();

        //_recoilHandler.SetRecoil();

        //_animator.SetBool("isFiring", true);

        //CheckHit();
    }
}
