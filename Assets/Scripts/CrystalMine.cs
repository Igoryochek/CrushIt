using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalMine : MonoBehaviour
{
    [SerializeField] private float _maximumFLyDistance;
    [SerializeField] private float _speed;
    [SerializeField] private Animator _animator;
    [SerializeField] private int _count;
    [SerializeField] private AudioSource _audioSource;

    private const float YOffset = 2;
    private Coroutine _moving;
    private Vector3 _newPosition;
    private bool _needToCollect = false;
    public int Count => _count;

    private void Start()
    {
        FlyAway();
    }

    public void FlyAway()
    {
        Vector2 randomPoint = Random.insideUnitCircle * _maximumFLyDistance;
        float yAxes;
        if (randomPoint.x + YOffset > transform.position.y)
        {
            yAxes = transform.position.y + randomPoint.x + YOffset;
        }
        else
        {
            yAxes = transform.position.y;
        }
        _newPosition = new Vector3(transform.position.x + randomPoint.x, yAxes, transform.position.z + randomPoint.y);
        Move(_newPosition);
    }

    public void MoveToCollect(CrystalCollector target)
    {
        _needToCollect = true;
        _animator.SetBool("Mined", true);
        Move(target);
        _audioSource.Play();
    }

    public void Move(Vector3 newPosition)
    {
        if (_moving != null)
        {
            StopCoroutine(_moving);
        }
        _moving = StartCoroutine(Moving(newPosition));

    }
    public void Move(CrystalCollector target)
    {
        if (_moving != null)
        {
            StopCoroutine(_moving);
        }
        _moving = StartCoroutine(Moving(target));

    }


    private IEnumerator Moving(CrystalCollector target)
    {
        Vector3 newPosition = new Vector3(target.transform.position.x, target.transform.position.y+1, target.transform.position.z);
        while (transform.position != target.transform.position)
        {
            newPosition = new Vector3(target.transform.position.x, target.transform.position.y + 1, target.transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, newPosition, _speed * Time.deltaTime);
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
            transform.position = Vector3.MoveTowards(transform.position, target, _speed * Time.deltaTime);
            yield return null;
        }
    }
}
