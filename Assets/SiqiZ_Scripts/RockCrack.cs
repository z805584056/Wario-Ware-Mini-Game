using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockCrack : MonoBehaviour {

    private AudioSource audioSource;
    public AudioClip crashClip;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        enabled = false;
    }
    void PlaySound()
    {
        audioSource.PlayOneShot(crashClip, 1f);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Rock"))
        {
            other.gameObject.SetActive(false);
            PlaySound();
        }
        else if (other.gameObject.CompareTag("Donut"))
        {
            other.gameObject.SetActive(false);
            PlaySound();
        }
    }
    
}
