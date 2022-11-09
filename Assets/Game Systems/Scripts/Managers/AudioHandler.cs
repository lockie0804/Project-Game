using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class AudioHandler : MonoBehaviour
{
    public AudioMixer masterAudio;
    private string _slider;
    public AudioSource audioSFX;
    public AudioClip[] audioClips;
    public void SelectSlider(string slider)
    {
        _slider = slider;
    }
    public void ChangeVolume(float volume)
    {
        masterAudio.SetFloat(_slider, volume);
    }
    private void Start()
    {
        audioSFX = GameObject.FindGameObjectWithTag("SFX").GetComponent<AudioSource>();
    }
    public void PlayClip()
    {
        int clip = Random.Range(0,audioClips.Length);
        audioSFX.clip = audioClips[clip];
        audioSFX.Play();
    }
}
