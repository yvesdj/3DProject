using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogController : MonoBehaviour
{
    private bool _isDone;
    //public IEventTrigger dialogueTrigger;

    public float minimumFog = 0.01f;
    public float maximumFog = 1f;
    public float transitionSpeed = 0.05f;
    private float _startingFog;
    private float _currentFog;


    void Start()
    {
        //dialogueTrigger = GetComponent<DialogueTrigger>();
        _isDone = false;
        _startingFog = RenderSettings.fogDensity;
        _currentFog = _startingFog;
    }

    // Update is called once per frame
    void Update()
    {
        if (_isDone == false && FindObjectOfType<DialogueManager>().isConversating == false) { DeFog(); } 

        if (_currentFog == minimumFog) { _isDone = true; }   
    }

    public void DeFog()
    {
        _currentFog = Mathf.Lerp(minimumFog, maximumFog, _startingFog);
        _startingFog -= transitionSpeed * Time.deltaTime;
        RenderSettings.fogDensity = _currentFog;
        Debug.Log(RenderSettings.fogDensity);
    }
}
