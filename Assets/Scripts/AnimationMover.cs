using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationMover : MonoBehaviour
{
    [SerializeField] private float _offsetY;
    [SerializeField] private float _movingSpeed;

    private Vector3 _startPosition;
    private Coroutine _movingUpDown;

    private void Update()
    {
        MoveUpDown();
    }

    public void MoveUpDown()
    {
        if (_movingUpDown == null)
        {
            _movingUpDown = StartCoroutine(MovingUpDown());
        }
    }

    private IEnumerator MovingUpDown()
    {
        _startPosition = transform.position;
        Vector3 newPosition = new Vector3(transform.position.x, transform.position.y + _offsetY, transform.position.z);
        while (transform.position != newPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position, newPosition, _movingSpeed * Time.deltaTime);
            yield return null;
        }
        while (transform.position != _startPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position, _startPosition, _movingSpeed * Time.deltaTime);
            yield return null;
        }
        _movingUpDown = null;
    }
}
