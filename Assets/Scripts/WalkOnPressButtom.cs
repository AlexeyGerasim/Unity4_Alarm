using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkOnPressButtom : MonoBehaviour
{
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            _animator.SetTrigger("Walk");
        }
        else if (Input.GetKey(KeyCode.A))
        {
            _animator.SetTrigger("Walk");
        }
        else
        {
            _animator.SetTrigger("Idle");
        }
    }
}
