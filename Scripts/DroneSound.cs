using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneSound : MonoBehaviour
{
    /*
     * Source code: https://answers.unity.com/questions/263010/adjust-audio-based-on-proximity.html
     * Author: GutoThomas
     * Retrieved date: 01/12/2020
     * Retrieved by: SHEK Chun Tong (190060819)
     * Item(s) changed / added: 1. Added [private AudioSource droneAudio] to get Audio Source component as 
     *                          Component.audio used in [audio.isPlaying] and [audio.volume] is obsolete.
     *                          2. Changed value of WaitForSeconds to 0.1f from 1 to makes the audio updated faster.
     */

    public Transform target;
    public float maxVolume;
    private AudioSource droneAudio;

    void Start()
    {
        droneAudio = this.GetComponent<AudioSource>();
        StartCoroutine(AdjustVolume());

    }

    IEnumerator AdjustVolume()
    {
        while (true)
        {
            if (droneAudio.isPlaying)
            { // do this only if some audio is being played in this gameObject's AudioSource

                float distanceToTarget = Vector3.Distance(transform.position, target.position); // Assuming that the target is the player or the audio listener

                if (distanceToTarget < 1) { distanceToTarget = 1; }

                droneAudio.volume = 1 / distanceToTarget; // this works as a linear function, while the 3D sound works like a logarithmic function, so the effect will be a little different (correct me if I'm wrong)

                if (droneAudio.volume > maxVolume) { droneAudio.volume = maxVolume; };

                yield return new WaitForSeconds(0.1f); // this will adjust the volume based on distance every 1 second (Obviously, You can reduce this to a lower value if you want more updates per second)

            }
        }
    }
}
