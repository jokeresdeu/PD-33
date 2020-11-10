using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesController : MonoBehaviour
{
    [SerializeField] private int _hp;

    public void TakeDamage(int damage)
    {
        _hp -= damage;
        if (_hp <= 0)
            OnDeath();
        Debug.Log("Damage = " + damage);
        Debug.Log("HP = " + _hp);
    }

    public void OnDeath()
    {
        Destroy(gameObject);
    }
}
