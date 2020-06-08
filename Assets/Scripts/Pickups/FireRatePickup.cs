using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireRatePickup : MonoBehaviour, IPickup
{
    public float timesROF;
    public float duration;

    public void EnhancePlayer(Collider player)
    {
        GunEffectHandler playerGun = player.GetComponentInChildren<GunEffectHandler>();
        playerGun.Multiplier = timesROF;
        playerGun.Duration = duration;
        playerGun.IsEnhanced = true;
    }
}
