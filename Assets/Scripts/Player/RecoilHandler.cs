using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecoilHandler : MonoBehaviour
{
    public float sideRecoilForce;
    public float upwardsRecoilForce;

    public float sideRecoil;
    public float upwardsRecoil;

    public void ResetRecoil()
    {
        sideRecoil = 0;
        upwardsRecoil = 0;
    }

    public void SetRecoil()
    {
        upwardsRecoil += upwardsRecoilForce;
        sideRecoil += sideRecoilForce;
    }
}
