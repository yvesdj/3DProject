using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireRatePickup : MonoBehaviour, IPickup
{
    public float timesROF;

    public void EnhancePlayer(Collider player)
    {
        Gun playerGun = player.GetComponentInChildren<Gun>();
        playerGun.fireRate *= timesROF;
        playerGun.IsEnhanced = true;
    }
}
