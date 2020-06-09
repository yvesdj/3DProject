using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLvlTrigger : MonoBehaviour
{
    [SerializeField]
    GameObject ending;

    public bool portalActivated = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!portalActivated)
        {
            ending.transform.position += new Vector3(0, 7, 0);
            portalActivated = true;
        }
    }
}
