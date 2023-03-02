using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimatorController : MonoBehaviour
{
    private Animator _animator;

    private const string Idle = "IdleShoot";
    private const string Run = "Run";
    private const string Fall = "Fall";

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void Walk()
    {
        if (_animator.GetBool(Run)==false)
        {
            _animator.SetBool(Run,true);
        }
    }

    public void StopWalk()
    {
        if (_animator.GetBool(Run))
        {
            _animator.SetBool(Run,false);
        }
    }
    
    public void Die()
    {
        if (_animator.GetBool(Fall)==false)
        {
            _animator.SetBool(Fall,true);
        }
    }
}
