using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectPicker : MonoBehaviour
{
    public AudioClip[] hitClips;
    public AudioClip[] dieClips;

    public AudioSource audioSource;
    public AudioListener audioListener;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponentInChildren<AudioSource>();
        audioListener = GetComponentInChildren<AudioListener>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayRandomHit()
    {
        audioSource.clip = hitClips[Random.Range(0, hitClips.Length)];
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }

    public void PlayRandomDie()
    {
        audioSource.clip = dieClips[Random.Range(0, dieClips.Length)];
        audioSource.Play();
    }
}
