using System.Collections;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private Color _reachedColor;

    private AudioSource _audioSource;
    private Coroutine fadeCoroutine;
    private VolumeController _volumeController;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _volumeController = GetComponent<VolumeController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        float targetVolume = 1f;

        if (collision.TryGetComponent<Player>(out Player player))
        {
            if (fadeCoroutine != null)
            {
                _volumeController.StopCoroutine(fadeCoroutine);
            }

            _renderer.color = _reachedColor;
            fadeCoroutine = _volumeController.StartCoroutine(_volumeController.WorkVolume(targetVolume));
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        float targetVolume = 0f;

        if (collision.TryGetComponent<Player>(out Player player))
        {
            if (fadeCoroutine != null && _audioSource.volume > targetVolume)
            {
                _volumeController.StopCoroutine(fadeCoroutine);
            }

            _renderer.color = Color.white;
            fadeCoroutine = _volumeController.StartCoroutine(_volumeController.WorkVolume(targetVolume));
        }
    }
}