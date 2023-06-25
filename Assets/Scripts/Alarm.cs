using System.Collections;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _renderer;
    private AudioSource _audioSource;
    private int count = 0;

    public void Siren()
    {
        count++;

        if (count % 2 == 1)
        {
            StartSiren(1f);
        }
        else
        {
            StartSiren(0f);
        }
    }

    private void StartSiren(float targetVolume)
    {
        StartCoroutine("WorkVolume", targetVolume);
    }

    public IEnumerator WorkVolume(float targetVolume)
    {
        float maxDelta = 0.001f;

        _audioSource = GetComponent<AudioSource>();
        _audioSource.Play();

        while (Mathf.Abs(_audioSource.volume - targetVolume) > maxDelta)
        {
            ChangeVolume(targetVolume, maxDelta);
            yield return null;
        }
    }

    private void ChangeVolume(float _targetVolume, float _maxDelta)
    {
        _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, _targetVolume, _maxDelta);
    }
}
