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
    public float damage = 10f;

    public float fireRate = 5f;
    private float _nextTimeToFire = 0f;

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
        //isEngaging = IsInRange();

        if (IsInRange())
        {
            transform.LookAt(target.transform);
        }

        if (IsLineOfSight())
        {
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
            GenerateScatteredShot();   
        }
    }

    private bool IsLineOfSight()
    {
        RaycastHit hit;
        if (Physics.Raycast(muzzleFlash.transform.position, muzzleFlash.transform.forward, out hit, maxEngageRange) && hit.transform.name == "Body")
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void GenerateScatteredShot()
    {
        Vector3 direction = GenerateScatter();

        direction = muzzleFlash.transform.TransformDirection(direction.normalized);

        RaycastHit shotHit;
        if (Physics.Raycast(muzzleFlash.transform.position, direction, out shotHit, maxEngageRange))
        {
            Debug.Log(shotHit.transform.name);
            CreateBulletTrail(shotHit);

            CreateImpact(shotHit);

            IHealthHandler target = shotHit.transform.GetComponentInParent<IHealthHandler>();

            if (target != null)
            {
                target.TakeDamage(damage);
            }
        }
    }

    private Vector3 GenerateScatter()
    {
        float randomRadius = scaleLimit;

        randomRadius = Random.Range(0, scaleLimit);

        float randomAngle = Random.Range(0, 2 * Mathf.PI);

        Vector3 direction = new Vector3(
            randomRadius * Mathf.Cos(randomAngle),
            randomRadius * Mathf.Sin(randomAngle),
            z
        );
        return direction;
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
