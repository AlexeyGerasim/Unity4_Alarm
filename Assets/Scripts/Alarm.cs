using System.Collections;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _renderer;

    private Coroutine sirenCoroutine;
    private AudioSource _audioSource;
    private bool isSirenActive = false;

    public void Siren()
    {
        isSirenActive = !isSirenActive;

        if (isSirenActive)
        {
            StopSiren();
            StartSiren(1f);
        }
        else
        {
            StopSiren();
            StartSiren(0f);
        }
    }

    private void StartSiren(float targetVolume)
    {
        sirenCoroutine = StartCoroutine(WorkVolume(targetVolume));
    }

    private void StopSiren()
    {
        if (sirenCoroutine != null)
        {
            StopCoroutine(sirenCoroutine);
        }
    }

    public IEnumerator WorkVolume(float targetVolume)
    {
        float maxDelta = 0.001f;

        _audioSource = GetComponent<AudioSource>();
        _audioSource.Play();

        float deltaVolume = Mathf.Abs(_audioSource.volume - targetVolume);

        while (deltaVolume > maxDelta)
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
