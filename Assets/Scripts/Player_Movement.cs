using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(SpriteRenderer))]
public class Player_Movement : MonoBehaviour
{
    private Rigidbody2D _playerRb;
    private SpriteRenderer _playerSprite;

    [SerializeField] GameObject _groundCheck;
    [SerializeField] float _radius;
    [SerializeField] LayerMask _whatIsGround;


    [SerializeField] float _speed;
    [SerializeField] float _jumpForce;
    [SerializeField] float _crawlSpeed;

    [SerializeField] Collider2D _headCollider;

    float _move;
    bool _canJump;
    bool _crawl;
    // Start is called before the first frame update
    private void Awake()
    {
        _playerRb = GetComponent<Rigidbody2D>();
        _playerSprite = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if(_move!=0)
        {

            if (_crawl)
                _crawlSpeed = 0.3f;
            else
                _crawlSpeed = 1;

            _playerRb.velocity = new Vector2(_move, _playerRb.velocity.y) * _speed * _crawlSpeed;
        }

        if(_move>0 && _playerSprite.flipX)
        {
            _playerSprite.flipX = false;
        }
        else if(_move < 0 && !_playerSprite.flipX)
        {
            _playerSprite.flipX = true;
        }
    }

    void Update()
    {
        _move = Input.GetAxisRaw("Horizontal");
        if (_move != 0)
            Debug.Log(_move);

        if(Input.GetKeyUp(KeyCode.Space) && _canJump) //Input.GetButtonUp("Jump")
        {
            _playerRb.AddForce(Vector2.up * _jumpForce);
        }

        
        if (Physics2D.OverlapCircle(_groundCheck.transform.position, _radius, _whatIsGround))
        {
            _canJump = true;
        }
        else
            _canJump = false;
        _crawl = Input.GetKey(KeyCode.C);

        if (_crawl && _headCollider.enabled)
        {
            _headCollider.enabled = false;
        }
        else if(!_crawl && !_headCollider.enabled)
        {
            _headCollider.enabled = true;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(_groundCheck.transform.position, _radius);
    }
}
