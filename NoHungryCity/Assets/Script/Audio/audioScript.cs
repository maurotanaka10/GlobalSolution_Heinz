using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioScript : MonoBehaviour
{
    [SerializeField] private AudioClip startTruck;
    [SerializeField] private AudioClip ContinuousTruck;
    [SerializeField] private AudioSource audioSourceTruck;
    void Start()
    {
        audioSourceTruck.clip= startTruck;
    }

    // Update is called once per frame
    void Update()
    {
        if (!audioSourceTruck.isPlaying)
        {
            audioSourceTruck.clip = ContinuousTruck;
            audioSourceTruck.Play();
        }
    }
}
