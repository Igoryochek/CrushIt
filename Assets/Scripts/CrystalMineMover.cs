using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalMineMover : MonoBehaviour
{
    [SerializeField] private float _maximumFLyDistance;
    [SerializeField] private float _speed;

    private const float YOffset = 2;

    private Vector3 _newPosition;
    private void Start()
    {
        Move();
    }

    public void Move()
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
        StartCoroutine(Moving());
    }

    private IEnumerator Moving()
    {
        Debug.Log(_newPosition);
        Debug.Log(transform.position);
        while (transform.position != _newPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position,_newPosition,_speed*Time.deltaTime);
            yield return null;
        }
    }
}
