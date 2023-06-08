using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimatorController : MonoBehaviour
{
    private Animator _animator;

    private const string IdleShoot = "IdleShoot";
    private const string Idle = "Idle";
    private const string Running = "Run";
    private const string Fall = "Fall";
    private const string RiseUp = "RiseUp";
    private const string Up = "Up";
    private const string Push = "Push";

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void Run()
    {
        if (_animator.GetBool(Running)==false)
        {
            if (_animator.GetBool(IdleShoot))
            {
                _animator.SetBool(IdleShoot, false);
            }
            _animator.SetBool(Running,true);
        }
    }

    public void StopRun()
    {
        if (_animator.GetBool(Running))
        {
            _animator.SetBool(Running,false);
        }
    }    public void StopShoot()
    {
        if (_animator.GetBool(IdleShoot))
        {
            _animator.SetBool(IdleShoot,false);
        }
    }

    public void StopRunAndShoot()
    {
        if (_animator.GetBool(Running))
        {
            _animator.SetBool(Running, false);
            _animator.SetBool(IdleShoot, true);
        }
    }
    
    public void Die()
    {
        StopRun();
        StopShoot();
        _animator.SetTrigger(Fall);
        
    }
    
    public void RisingUp()
    {
        _animator.SetTrigger(RiseUp);        
    }
    
    public void StandUp()
    {
        if (_animator.GetBool(Up)==false)
        {
            _animator.SetBool(Up,true);
        }
    }
    
    public void StopStandUp()
    {
        if (_animator.GetBool(Up))
        {
            _animator.SetBool(Up,false);
        }
    }
    public void PushButton()
    {
        if (_animator.GetBool(Running))
        {
            _animator.SetBool(Running,false);
        }
        _animator.SetTrigger(Push);
    }
}
