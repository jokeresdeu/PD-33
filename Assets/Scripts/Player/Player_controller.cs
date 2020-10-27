using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_controller : MonoBehaviour
{
    private ServiceManager _serviceManager;
    [SerializeField] private int _maxHP;
    private int _currentHP;
    [SerializeField] private int _maxMP;
    private int _currentMP;

    [SerializeField] Slider _hpSlider;
    [SerializeField] Slider _mpSlider;

    Movement_controller _playerMovement;
    Vector2 _startPosition;

    private bool _canBeDamaged = true;
    void Start()
    {
        _playerMovement = GetComponent<Movement_controller>();
        _playerMovement.OnGetHurt += OnGetHurt;
        _currentHP = _maxHP;
        _currentMP = _maxMP;
        _hpSlider.maxValue = _maxHP;
        _hpSlider.value = _maxHP;
        _mpSlider.maxValue = _maxMP;
        _mpSlider.value = _maxMP;
        _startPosition = transform.position;
        _serviceManager = ServiceManager.Instanse;
    }

    public void TakeTamage(int damage, DamageType type = DamageType.Casual, Transform enemy = null)
    {
        if (!_canBeDamaged)
            return;

        _currentHP -= damage;
        if (_currentHP <= 0)
        {
            OnDeath();
        }

        switch(type)
        {
            case DamageType.PowerStrike:
                _playerMovement.GetHurt(enemy.position);
                break;
        }
        _hpSlider.value = _currentHP;
    }

    private void OnGetHurt(bool canBeDamaged)
    {
        _canBeDamaged = canBeDamaged;
    }

    public void RestoreHP(int hp)
    {
        _currentHP += hp;
        if (_currentHP > _maxHP)
        {
            _currentHP = _maxHP;
        }
        _hpSlider.value = _currentHP;
    }

    public bool ChangeMP(int value)
    {
        if (value < 0 && _currentMP < Mathf.Abs(value))
            return false;
        
        _currentMP += value;
        if (_currentMP > _maxMP)
            _currentMP = _maxMP;
        _mpSlider.value = _currentMP;
        return true;
    }

    public void OnDeath()
    {
        _serviceManager.Restart();
    }
}
