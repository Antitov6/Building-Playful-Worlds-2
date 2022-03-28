using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBlockSound : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;

    public void PlayPlayerBlockSound()
    {
        audioSource.Play();
    }
}
