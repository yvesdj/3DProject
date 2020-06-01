using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGunHandler : MonoBehaviour
{
    public GameObject target;
    private AudioSource _audioSource;
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;
    public LineRenderer bulletTrail;

    public float maxEngageRange;
    private bool isEngaging;

    public float fireRate = 5f;
    private float _nextTimeToFire = 0f;
    //public float scatterAmount;

    public float scaleLimit = 2.0f;
    public float z = 10f;

    public float impactForce = 5f;

    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
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
            _audioSource.Play();
            CheckHit();
        }
        
        //_audioSource.Play();

        //_recoilHandler.SetRecoil();

        //_animator.SetBool("isFiring", true);

        
    }

    private void CheckHit()
    {
        //  Try this one first, before using the second one
        //  The Ray-hits will form a ring
        float randomRadius = scaleLimit;
        //  The Ray-hits will be in a circular area
        randomRadius = Random.Range(0, scaleLimit);

        float randomAngle = Random.Range(0, 2 * Mathf.PI);

        //Calculating the raycast direction
        Vector3 direction = new Vector3(
            randomRadius * Mathf.Cos(randomAngle),
            randomRadius * Mathf.Sin(randomAngle),
            z
        );

        //Make the direction match the transform
        //It is like converting the Vector3.forward to transform.forward
        direction = muzzleFlash.transform.TransformDirection(direction.normalized);



        RaycastHit hit;
        if (Physics.Raycast(muzzleFlash.transform.position, direction, out hit, maxEngageRange))
        {
            Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();

            //if rigidbody with fysics
            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
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
        }
        else
        {
            //Render when shooting at nothing
            //lineRenderer.SetPosition(1, );
        }

        Destroy(bulletTrailEffect, 1f);
    }
}
