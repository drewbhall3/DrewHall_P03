using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Connected GameObjects")]

    [SerializeField] AudioSource audio;

    [Header("Audio Clips")]

    [SerializeField] AudioClip Damage;
    [SerializeField] AudioClip ThunderShock;
    [SerializeField] AudioClip Scratch;
    [SerializeField] AudioClip Bite;
    [SerializeField] AudioClip Tackle;
    [SerializeField] AudioClip Faint;
    [SerializeField] AudioClip Beep;


    // Update is called once per frame
    public void PlayAudio(float num)
    {
        if(num == 1)
        {
            audio.clip = Damage;
            audio.Play();
        }
        if (num == 2)
        {
            audio.clip = ThunderShock;
            audio.Play();
        }
        if (num == 3)
        {
            audio.clip = Scratch;
            audio.Play();
        }
        if (num == 4)
        {
            audio.clip = Bite;
            audio.Play();
        }
        if (num == 5)
        {
            audio.clip = Tackle;
            audio.Play();
        }
        if (num == 6)
        {
            audio.clip = Faint;
            audio.Play();
        }
        if (num == 7)
        {
            audio.clip = Beep;
            audio.Play();
        }

    }
}
