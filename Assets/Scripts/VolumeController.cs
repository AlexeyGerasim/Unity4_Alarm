using System.Collections;
using UnityEngine;

public class VolumeController : MonoBehaviour
{
    private AudioSource _audioSource;

    public IEnumerator WorkVolume(float _targetVolume)
    {
        float _maxDelta = 0.001f;

        _audioSource = GetComponent<AudioSource>();
        _audioSource.Play();

        if (_targetVolume == 1f)
        {
            while (_audioSource.volume < _targetVolume)
            {
                ChangeVolume(_targetVolume, _maxDelta);

                yield return null;
            }

        }
        else if (_targetVolume == 0f)
        {
            while (_audioSource.volume > _targetVolume)
            {
                ChangeVolume(_targetVolume, _maxDelta);

                yield return null;
            }
        }
    }

    private void ChangeVolume(float _targetVolume, float _maxDelta)
    {
        _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, _targetVolume, _maxDelta);
    }
}
