using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunEffectHandler : MonoBehaviour
{
    private Gun _gun;

    private float _originalROF;
    private float _originalSideRecoil;
    private float _originalUpRecoil;

    public bool IsEnhanced { get; set; }
    public float Multiplier { get; internal set; }
    public float Duration { get; internal set; }

    private void Awake()
    {
        _gun = GetComponent<Gun>();
    }

    // Start is called before the first frame update
    void Start()
    {
        _originalROF = _gun.fireRate;
        _originalSideRecoil = _gun.sideRecoilForce;
        _originalUpRecoil = _gun.upwardsRecoilForce;

        IsEnhanced = false;
    }

    // Update is called once per frame
    void Update()
    {
        ActivateEffect();
    }

    public void ActivateEffect()
    {
        if (IsEnhanced)
        {
            _gun.fireRate *= Multiplier;
            _gun.sideRecoilForce /= Multiplier;
            _gun.upwardsRecoilForce /= Multiplier;

            StartCoroutine(ReturnToNormalAfterTime());
            IsEnhanced = false;
        }
    }

    IEnumerator ReturnToNormalAfterTime()
    {
        yield return new WaitForSeconds(Duration);

        _gun.fireRate = _originalROF;
        _gun.sideRecoilForce = _originalSideRecoil;
        _gun.upwardsRecoilForce = _originalUpRecoil;
    }
}
