using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundManagerScript : MonoBehaviour
{
    public static AudioClip boxPick;

    static AudioSource audioSrc;

    void Start()
    {
        boxPick = Resources.Load<AudioClip> ("boxPick");

        audioSrc = GetComponent<AudioSource>();
    }

    public static void playSound(string clip)
    {
        if (clip == "boxPick") {
            audioSrc.PlayOneShot(boxPick);
        }
    }
}
