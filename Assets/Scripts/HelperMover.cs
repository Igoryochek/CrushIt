using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelperMover : Mover
{
    private bool _needUp=true;

    private void Start()
    {
        _animatorController.StandUp();
        StartCoroutine(StartDelay());
    }
    public override void Move()
    {
        if (_needUp==false)
        {

        }
        else
        {

        }
    }

    private IEnumerator StartDelay()
    {
        yield return new WaitForSeconds(1);
        _animatorController.StopStandUp();
        _needUp = false;
    }
}
