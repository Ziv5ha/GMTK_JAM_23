using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    [SerializeField] private AudioSource AudioSourceRef;
    [SerializeField] private AudioClip Punch;
    [SerializeField] private AudioClip CrouchPunch;
    [SerializeField] private AudioClip Kick;
    [SerializeField] private AudioClip CrouchKick;

    public void PlayPunch(bool IsCrouching) {
        AudioSourceRef.clip = IsCrouching ? CrouchPunch : Punch;
        AudioSourceRef.Play();
    }
    public void PlayKick(bool IsCrouching) {
        AudioSourceRef.clip = IsCrouching ? CrouchKick : Kick;
        AudioSourceRef.Play();
    }
}
