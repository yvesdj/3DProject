using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public IHealthHandler HealthHandler;
    public float health;

    // Start is called before the first frame update
    void Start()
    {
        HealthHandler = GetComponent<IHealthHandler>();
        HealthHandler.Health = health;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
