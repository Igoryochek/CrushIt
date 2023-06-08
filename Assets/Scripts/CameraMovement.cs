using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private float _zOffset;
    [SerializeField] private float _yMaxOffset;
    [SerializeField] private float _speed;
    [SerializeField] private float _viewAllDelay;

    private Vector3 _startPosition;
    private bool _isViewing=false;
    private Coroutine _viewing;

    private void Update()
    {
        if (_isViewing==false)
        {
            transform.position = new Vector3(_player.transform.position.x, transform.position.y, _player.transform.position.z - _zOffset);
        }
    }

    public void ViewAll()
    {
        if (_viewing==null)
        {
            _viewing=StartCoroutine(ViewingAll());
        }
    }

    private IEnumerator ViewingAll()
    {
        _isViewing = true;
        _startPosition = transform.position;
        Vector3 newPosition = new Vector3(transform.position.x,_startPosition.y+_yMaxOffset,
            transform.position.z-_zOffset);
        while (transform.position.y!=newPosition.y)
        {
            transform.position = Vector3.MoveTowards(transform.position,newPosition,_speed*Time.deltaTime);
            yield return null;
        }
        yield return new WaitForSeconds(_viewAllDelay);
        while (transform.position.y!=_startPosition.y)
        {
            transform.position = Vector3.MoveTowards(transform.position,_startPosition,_speed*Time.deltaTime);
            yield return null;

        }
        _viewing = null;
        _isViewing = false;
    }
}
