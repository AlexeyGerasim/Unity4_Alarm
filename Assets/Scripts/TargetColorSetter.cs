using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetColorSetter : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private Color _targetColor;
    private int count = 0;

    public void Change()
    {
        count++;

        if (count % 2 == 1)
        {
            _renderer.color = _targetColor;
        }
        else
        {
            _renderer.color = Color.white;
        }
    }
}
