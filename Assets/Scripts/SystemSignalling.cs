using UnityEngine;

public class SystemSignalling : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private Haus _haus;

    private float _speedChange = 0.1f;
    private float _minVolume = 0;
    private float _maxVolume = 1;
    private bool _play = false;

    private void OnEnable()
    {
        _haus.SoundStart += StartSound;
        _haus.SoundStop += StopSound;
    }

    private void OnDisable()
    {
        _haus.SoundStart -= StartSound;
        _haus.SoundStop -= StopSound;
    }  
   
    private void Start()
    {
        _audioSource.Play();
    }
    
    private void Update()
    {
        if (_play)
        {           
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, _maxVolume, _speedChange * Time.deltaTime);
        }
        else
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, _minVolume, _speedChange * Time.deltaTime);
        }
    }

    private void StartSound()
    {
        _play = true;
    }

    private void StopSound()
    {
        _play = false;
    }
}