using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _range;
    private Vector2 _startPoint;
    private int _direction = 1;
    void Start()
    {
        _startPoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y - _startPoint.y > _range && _direction >0)
        {
            _direction *= -1;
        }
        else if( _startPoint.y - transform.position.y > _range && _direction < 0)
        {
            _direction *= -1;
        }

        transform.Translate(0, _speed * _direction * Time.deltaTime, 0);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(0.5f, _range*2, 0));
    }
}
