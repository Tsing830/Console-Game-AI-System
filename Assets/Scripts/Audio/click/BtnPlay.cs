using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnPlay : MonoBehaviour
{
    public AudioClip clip;
    public AudioSource source;
    public void click()
    {
        source.PlayOneShot(clip);
    }
}