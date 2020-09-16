using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class FireBallController : MonoBehaviour
{
    [SerializeField] private float _startSpeed;
    Rigidbody2D _fireballRb;

    void Start()
    {
        //_fireballRb = GetComponent<Rigidbody2D>();
        //_fireballRb.velocity = Vector2.right * _startSpeed;
        Destroy(gameObject, 5f);
    }
}
