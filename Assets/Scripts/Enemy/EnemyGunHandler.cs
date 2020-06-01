using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGunHandler : MonoBehaviour
{
    public GameObject target;

    public ParticleSystem muzzleFlash;

    // Start is called before the first frame update
    void Start()
    {
        //target = Enemy
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target.transform);
        muzzleFlash.Play();
    }
}
