using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private int _maxHP;
    private int _currentHP;

    void Start()
    {
        _currentHP = _maxHP;
    }

    public void ChangeHP(int value)
    {
        _currentHP += value;
        if(_currentHP > _maxHP)
         _currentHP = _maxHP;
        if (_currentHP <= 0)
            OnDeath();

        Debug.Log("Value = " + value);
        Debug.Log("Current HP = " + _currentHP);
    }

    public void OnDeath()
    {
        Destroy(gameObject);
    }
}
