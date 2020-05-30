using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecoilHandler : MonoBehaviour
{
    private MouseLook _mouseLook;

    public float sideRecoil;
    public float upwardsRecoil;

    private void Awake()
    {
        _mouseLook = GetComponent<MouseLook>();
    }

    public void DoRecoil()
    {
        _mouseLook.RecoilBack(upwardsRecoil, sideRecoil);
        Debug.Log("Recoil");
    }
}
