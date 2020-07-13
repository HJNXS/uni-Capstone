using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundRandom : MonoBehaviour
{
    public AudioSource player;
    public List<AudioClip> clipList;
    public void PlayRandom()
    {
        int clipNum = Random.Range(0, clipList.Capacity);
        player.clip = clipList[clipNum];
        player.Play();
    }
}
