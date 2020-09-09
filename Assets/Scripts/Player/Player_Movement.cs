using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player_Movement : MonoBehaviour
{
    private Rigidbody2D _playerRb;
    private Animator _playerAnimator;

    [Header("Horizontal move")]
    [SerializeField] float _speed;

    [Header("Jumping")]
    [SerializeField] float _jumpForce;
    [SerializeField] float _radius;
    [SerializeField] bool _airControll;
    [SerializeField] Transform _groundCheck;
    [SerializeField] LayerMask _whatIsGround;

    [Header("Craawling")]
    [Range(0, 1)]
    [SerializeField] float _crawlSpeed;
    [SerializeField] Transform _cellCheck;
    [SerializeField] Collider2D _headCollider;


    private int _jumpCounter;
    private bool _grounded;
    private bool _canStand;
    private bool _faceRight = true;

    // Start is called before the first frame update
    private void Awake()
    {
        _playerRb = GetComponent<Rigidbody2D>();
        _playerAnimator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        _canStand = !Physics2D.OverlapCircle(_cellCheck.position, _radius, _whatIsGround);

        if(Physics2D.OverlapCircle(_groundCheck.position, _radius, _whatIsGround))
        {
            _grounded = true;
            _jumpCounter = 0;
        }
        else
        {
            _grounded = false;
        }
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(_groundCheck.position, _radius);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_cellCheck.position, _radius);
    }

    public void Move(float move, bool jump, bool crawling)
    {
        #region HorizontalMovement
        float modificate = 1;
        if (move != 0 && (_grounded || _airControll))
        {
            if (crawling)
                modificate = _crawlSpeed;
            _playerRb.velocity = new Vector2(move * _speed * modificate, _playerRb.velocity.y);
        }
        else if (move == 0 && _grounded)
        {
            _playerRb.velocity = new Vector2(0, _playerRb.velocity.y);
        }

        if (move > 0 && !_faceRight)
            Flip();
        else if (move < 0 && _faceRight)
            Flip();
        #endregion

        #region Jumping
       
        if (jump && (_grounded|| _jumpCounter<2)) 
        {
            _jumpCounter++;
            _playerRb.AddForce(Vector2.up * _jumpForce);
        }
        #endregion

        #region Crawling
        if (crawling && _headCollider.enabled)
        {
            _headCollider.enabled = false;
        }
        else if (!crawling && !_headCollider.enabled && _canStand)
        {
            _headCollider.enabled = true;
        }
        #endregion

        #region Animation
        _playerAnimator.SetBool("Jump", !_grounded);
        _playerAnimator.SetBool("Crawl", !_headCollider.enabled);
        _playerAnimator.SetFloat("Speed", Mathf.Abs(move));
        #endregion 
    }

    void Flip()
    {
        _faceRight = !_faceRight;
        transform.Rotate(0, 180, 0);
    }
}
