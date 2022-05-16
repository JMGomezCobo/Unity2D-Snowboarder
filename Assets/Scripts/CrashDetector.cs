using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{ 
    [SerializeField] private float loadDelay = 0.5f;
    [SerializeField] private ParticleSystem crashEffect;
    [SerializeField] private AudioClip crashSFX;

    private bool hasCrashed;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Ground") || hasCrashed) return;
        
        hasCrashed = true;
        
        FindObjectOfType<PlayerController>().DisableControls();
        
        crashEffect.Play();
        GetComponent<AudioSource>().PlayOneShot(crashSFX);
        
        Invoke(nameof(ReloadScene), loadDelay);
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
