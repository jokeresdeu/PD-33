using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_controller : MonoBehaviour
{
    [SerializeField] private int _maxHP;
    private int _currentHP;
    [SerializeField] private int _maxMP;
    private int _currentMP;

    void Start()
    {
        _currentHP = _maxHP;
        _currentMP = _maxMP;
    }

    public void ChangeHp(int value)
    {
        _currentHP += value;
        if(_currentHP > _maxHP)
        {
            _currentHP = _maxHP;
        }
        else if(_currentHP <=0)
        {
            OnDeath();
        }
        Debug.Log("Value = " + value);
        Debug.Log("Current HP = " + _currentHP);
    }

    public bool ChangeMP(int value)
    {
        Debug.Log("MP value = " + value);
        if (value < 0 && _currentMP < Mathf.Abs(value))
            return false;
        
        _currentMP += value;
        if (_currentMP > _maxMP)
            _currentMP = _maxMP;
        Debug.Log("Current MP = " + _currentMP);
        return true;
    }

    public void OnDeath()
    {
        Destroy(gameObject);
    }
}
