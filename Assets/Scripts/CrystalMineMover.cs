using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalMineMover : MonoBehaviour
{
    [SerializeField] private float _maximumFLyDistance;
    [SerializeField] private float _speed;
    [SerializeField] private Animator _animator;

    private const float YOffset = 2;
    private Coroutine _moving;
    private Vector3 _newPosition;
    private bool _needToCollect=false;
    private void Start()
    {
        FlyAway();
    }

    public void FlyAway()
    {
        Vector2 randomPoint = Random.insideUnitCircle * _maximumFLyDistance;
        float yAxes;
        if (randomPoint.x+YOffset> transform.position.y)
        {
            yAxes = transform.position.y + randomPoint.x+YOffset;
        }
        else
        {
            yAxes = transform.position.y;
        }
        _newPosition = new Vector3(transform.position.x + randomPoint.x, yAxes, transform.position.z + randomPoint.y);
        Move(_newPosition);
    }

    public void MoveToCollect(Transform target)
    {
        _needToCollect = true;
        _animator.SetBool("Mined",true);
        Move(target);
    }

    public void Move(Vector3 newPosition)
    {
        if (_moving!=null)
        {
            StopCoroutine(_moving);
        }
            _moving= StartCoroutine(Moving(newPosition));

    }
    public void Move(Transform target)
    {
        if (_moving!=null)
        {
            StopCoroutine(_moving);
        }
            _moving= StartCoroutine(Moving(target));

    }


    private IEnumerator Moving(Transform target)
    {
        while (transform.position != target.position)
        {
            transform.position = Vector3.MoveTowards(transform.position,target.position,_speed*Time.deltaTime);
            yield return null;
        }
       
        if (_needToCollect)
        {
            gameObject.SetActive(false);
        }
    } 
    
    private IEnumerator Moving(Vector3 target)
    {
        while (transform.position != target)
        {
            transform.position = Vector3.MoveTowards(transform.position,target,_speed*Time.deltaTime);
            yield return null;
        }
    }
}
