using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpinner : MonoBehaviour
{
    public float degreesPerSecond;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, Time.deltaTime * degreesPerSecond, 0);
    }
}
