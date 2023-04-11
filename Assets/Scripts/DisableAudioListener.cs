using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableAudioListener : MonoBehaviour
{
    private AudioListener audioListener;

    void Start()
    {
        audioListener = GetComponent<AudioListener>();
        AudioListener[] audioListeners = FindObjectsOfType<AudioListener>();

        if (audioListeners.Length > 1 && audioListener != null)
        {
            audioListener.enabled = false;
            enabled = false;
        }
    }

    void Update()
    {
        if (audioListener.enabled && FindObjectsOfType<AudioListener>().Length > 1)
        {
            audioListener.enabled = false;
            enabled = false;
        }
    }
}
