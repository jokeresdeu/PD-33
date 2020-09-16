using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PC_InputController : MonoBehaviour
{
    [SerializeField]Player_Movement _playerMovement;
    private float _move;
    private bool _jump;
    private bool _crawling;

    void Update()
    {
        _move = Input.GetAxisRaw("Horizontal");
        _crawling = Input.GetKey(KeyCode.C);
        if(Input.GetButtonUp("Jump"))
        {
            _jump = true;
        }

        if(Input.GetKeyUp(KeyCode.E))
        {
            _playerMovement.StartCasting();
        }
    }

    private void FixedUpdate()
    {
        _playerMovement.Move(_move, _jump, _crawling);
        _jump = false;
    }
}
