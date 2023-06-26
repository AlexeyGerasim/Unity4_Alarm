using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class WalkOnPressButtom : MonoBehaviour
{
    private Animator _animator;
    private int walkHash;
    private int idleHash;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        walkHash = Animator.StringToHash("Walk");
        idleHash = Animator.StringToHash("Idle");
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            _animator.SetTrigger(walkHash);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            _animator.SetTrigger(walkHash);
        }
        else
        {
            _animator.SetTrigger(idleHash);
        }
    }
}
