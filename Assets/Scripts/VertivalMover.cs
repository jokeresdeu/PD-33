using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VertivalMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _range;
    private Vector2 _startPosition;
    private int _direction =1;
    private int nextDirection = -1;
    // Start is called before the first frame update
    void Start()
    {
        _startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, _speed * _direction * Time.deltaTime, 0);
        if(Vector2.Distance(_startPosition, transform.position) > _range && _direction != nextDirection)
        {
            _direction *= -1;
        }
        else if(Vector2.Distance(_startPosition, transform.position) < _range && _direction == nextDirection)
        {
            nextDirection *= -1;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(0.5f, _range * 2, 0));
    }
}
