using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _healthEnemy;
    [SerializeField] public int _moneyForDeath;
    public void Takedamage(float amount)
    {
        _healthEnemy -= amount;

        if(_healthEnemy < 0)
        {
            Die();
        }
    }
    

    private void Die()
    {
        PlayerStats.Money += _moneyForDeath;
        Destroy(gameObject);
    }

}
 