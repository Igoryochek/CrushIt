using System.Collections;
using UnityEngine;

public class AnimationMover : MonoBehaviour
{
    [SerializeField] private float _offsetY;
    [SerializeField] private float _movingSpeed;

    private Vector3 _startPosition;
    private Coroutine _movingUpDown;

    private void Update()
    {
        Move();
    }

    public void Move()
    {
        if (_movingUpDown == null)
        {
            _movingUpDown = StartCoroutine(Moving());
        }
    }

    private IEnumerator Moving()
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
