using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SiZh_RabbitDead : MonoBehaviour {
    private AudioSource audioSource;
    public AudioClip deathClip;
    // Use this for initialization
    void Start () {
        audioSource = GetComponent<AudioSource>();

        enabled = false;
    }
    void PlaySound()
    {
        audioSource.PlayOneShot(deathClip, 10f);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Rabbit"))
        {

            Destroy(other.gameObject);

            PlaySound();
        }
    }

}
