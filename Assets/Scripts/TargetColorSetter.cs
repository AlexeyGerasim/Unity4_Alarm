using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetColorSetter : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private Color _targetColor;

    private bool isSirenActive = false;

    public void Change()
    {
        isSirenActive = !isSirenActive;

        if (isSirenActive)
        {
            _renderer.color = _targetColor;
        }
        else
        {
            _renderer.color = Color.white;
        }
    }
}
