using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource SFX_PlayerChomp;
    public AudioSource SFX_SharkChomp;
    public AudioSource SFX_JellyfishZap;

    public void Sound_EatFish()
    {
        SFX_PlayerChomp.Play();
    }

    public void Sound_HitShark()
    {
        SFX_SharkChomp.Play();
    }

    public void Sound_HitJelly()
    {
        SFX_JellyfishZap.Play();
    }
}
