using System.Collections;
using UnityEngine;

public class AlarmOperation : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private Hous _hous;

    private float _speedChange = 0.1f;
    private float _minVolume = 0;
    private float _maxVolume = 1;
    private float _delay = 0.5f;
    private bool _play = false;
    private Coroutine _coroutine;

    private void OnEnable()
    {
        _hous.MovementDetected += StartSound;        
        _hous.NoMovementDetected += StopSound;
    }

    private void OnDisable()
    {
        _hous.MovementDetected -= StartSound;
        _hous.NoMovementDetected -= StopSound;
    }  
   
    private void Start()
    {
        _audioSource.Play();
        _audioSource.volume = 0;
    }    

    private void StartSound()
    {
        _play = true;
        SelectionVolume();
    }

    private void StopSound()
    {
        _play = false;
        SelectionVolume();              
    }

    private void SelectionVolume()
    {
        float finalVolume;

        if (_coroutine != null)
            StopCoroutine(_coroutine);

        if(_play)
            finalVolume = _maxVolume;        
        else
            finalVolume = _minVolume;

        _coroutine = StartCoroutine(VolumeChange(_delay, _audioSource.volume, finalVolume, _speedChange));
    }

    private IEnumerator VolumeChange(float delay, float currentVolume, float targetVolume, float speedChange)
    {
        var wait = new WaitForSeconds(delay);

        while (currentVolume != targetVolume)
        {
            _audioSource.volume = Mathf.MoveTowards(currentVolume, targetVolume, speedChange);
            currentVolume = _audioSource.volume;
            yield return wait;
        }        
    }
}