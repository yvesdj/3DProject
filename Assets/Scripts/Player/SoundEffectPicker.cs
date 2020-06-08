using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectPicker : MonoBehaviour
{
    public AudioClip[] hitClips;
    public AudioClip[] dieClips;
    public AudioClip[] zingerClips;

    public AudioSource[] audioSources;
    public AudioListener audioListener;

    // Start is called before the first frame update
    void Awake()
    {
        audioSources = GetComponents<AudioSource>();
        audioListener = GetComponentInChildren<AudioListener>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayRandomHit()
    {
        audioSources[0].clip = hitClips[Random.Range(0, hitClips.Length)];
        if (!audioSources[0].isPlaying)
        {
            audioSources[0].Play();
        }
    }

    public void PlayRandomDie()
    {
        audioSources[0].clip = dieClips[Random.Range(0, dieClips.Length)];
        audioSources[0].Play();
    }

    public void PlayRandomZinger()
    {
        audioSources[1].clip = zingerClips[Random.Range(0, zingerClips.Length)];
        audioSources[1].Play();
    }
}
