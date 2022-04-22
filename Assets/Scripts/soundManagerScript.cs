using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundManagerScript : MonoBehaviour
{
    public static AudioClip boxPick;
    public static AudioClip clickUI;
    public static AudioClip hitCloud;

    static AudioSource audioSrc;

    void Start()
    {
        boxPick = Resources.Load<AudioClip> ("boxPick");

        clickUI = Resources.Load<AudioClip> ("clickUI");

        hitCloud = Resources.Load<AudioClip> ("hitCloud");

        audioSrc = GetComponent<AudioSource>();
    }

    public static void playSound(string clip)
    {
        if (clip == "boxPick") {
            audioSrc.PlayOneShot(boxPick);
        }
        else if (clip == "clickUI") {
            audioSrc.PlayOneShot(clickUI);
        }
        else if (clip == "hitCloud") {
            audioSrc.PlayOneShot(hitCloud);
        }
    }
}
