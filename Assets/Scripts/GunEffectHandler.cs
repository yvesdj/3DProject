using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunEffectHandler : MonoBehaviour
{
    private Gun _gun;

    private float _originalROF;
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
            StartCoroutine(ReturnToNormalAfterTime());
            IsEnhanced = false;
        }
    }

    IEnumerator ReturnToNormalAfterTime()
    {
        yield return new WaitForSeconds(Duration);

        //IsEnhanced = false;
        _gun.fireRate = _originalROF;
    }
}
