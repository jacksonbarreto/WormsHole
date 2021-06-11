using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioSource backgroundMusic;
    public AudioSource audioSourceFX;
    public AudioClip[] audioClips;
    // Start is called before the first frame update
    void Start()
    {
        int indexAudioClip = Random.Range(0, audioClips.Length);
        AudioClip currentMusic = audioClips[indexAudioClip];
        backgroundMusic.loop = true;       
        backgroundMusic.clip = currentMusic;
        backgroundMusic.Play();
    }

   public void playAudioSFX(AudioClip audioClip)
    {
        audioSourceFX.PlayOneShot(audioClip);
    }
}
