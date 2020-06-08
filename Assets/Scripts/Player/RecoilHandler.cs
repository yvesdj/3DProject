using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecoilHandler : MonoBehaviour
{
    public float sideRecoil;
    public float upwardsRecoil;

    public void ResetRecoil()
    {
        sideRecoil = 0;
        upwardsRecoil = 0;
    }

    public void SetRecoil(float upwardsRecoilForce, float sideRecoilForce)
    {
        upwardsRecoil += upwardsRecoilForce;
        sideRecoil += sideRecoilForce;
    }
}
