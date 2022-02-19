using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] GameObject m_AudioSource;
 
    public void PlaySound(AudioClip clip)
    {
        AudioSource audioSource = Instantiate(m_AudioSource, transform.position, Quaternion.identity).GetComponent<AudioSource>();
        audioSource.clip = clip;
        audioSource.Play();
        Destroy(audioSource.gameObject, audioSource.clip.length);
    }
}
