using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private float _timeDelay;
    private DateTime _lastEncounter;
    private PlayerController _player;

    private void OnTriggerEnter2D(Collider2D info)
    {
        if((DateTime.Now - _lastEncounter).TotalSeconds < 0.02f)
        {
            return;
        }
        _lastEncounter = DateTime.Now;
        _player = info.GetComponent<PlayerController>();
        if (_player != null)
            _player.ChangeHP(-_damage);
    }

    private void OnTriggerExit2D(Collider2D info)
    {
        if (_player == info.GetComponent<PlayerController>())
            _player = null; 
    }

    // Update is called once per frame
    void Update()
    {
        if(_player!=null && (DateTime.Now - _lastEncounter).TotalSeconds > _timeDelay)
        {
            _player.ChangeHP(-_damage);
            _lastEncounter = DateTime.Now;
        }
    }
}
