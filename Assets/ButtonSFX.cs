using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSFX : MonoBehaviour
{
    public AudioSource soundPlayer;

    public void playThisSoundEffect()
    {
        soundPlayer.Play();
    }

}
