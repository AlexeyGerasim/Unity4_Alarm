using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed;

    private SpriteRenderer _renderer;

    private void Update()
    {
        _renderer = GetComponent<SpriteRenderer>();

        if (Input.GetKey(KeyCode.D))
        {
            _renderer.flipX = false;
            transform.Translate(_speed * Time.deltaTime, 0, 0);
        } 

        if (Input.GetKey(KeyCode.A))
        {
            _renderer.flipX = true;
            transform.Translate(_speed * Time.deltaTime*-1, 0, 0);
        } 
    }
}