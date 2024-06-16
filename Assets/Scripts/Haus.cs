using System;
using UnityEngine;

public class Haus : MonoBehaviour
{
    public event Action SoundStart;
    public event Action SoundStop;

    private void OnTriggerEnter(Collider other)
    {
        SoundStart?.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {        
        SoundStop?.Invoke();
    }
}