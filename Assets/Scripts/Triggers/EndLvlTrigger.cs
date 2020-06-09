using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLvlTrigger : MonoBehaviour
{
    [SerializeField]
    GameObject ending;

    [SerializeField]
    Transform respawnPoint;

    public bool portalActivated = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!portalActivated)
        {
            ending.transform.position += new Vector3(0, 7, 0);
            FindObjectOfType<Player>().transform.position = respawnPoint.transform.position;
            FindObjectOfType<Player>().GetComponent<PlayerHealthHandler>().ResetHealth();
            portalActivated = true;
        }
    }
}
