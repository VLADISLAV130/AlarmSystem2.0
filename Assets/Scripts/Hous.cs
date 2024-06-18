using System;
using UnityEngine;

public class Hous : MonoBehaviour
{
    [SerializeField] private Bandit _bandit;

    public event Action MovementDetected;
    public event Action NoMovementDetected;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Bandit bandit))
            MovementDetected?.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Bandit bandit))
            NoMovementDetected?.Invoke();
    }
}