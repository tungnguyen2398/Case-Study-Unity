using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public HealthComponent health;
    private bool isDead = false;
    public EnemySO enemySO;
    public UnitSpawner spawner;

    private void Start()
    {
        if (enemySO != null && health != null)
        {
            health.SetHp(enemySO.Hp);
        }
    }

    public void SetData(EnemySO data)
    {
        this.enemySO = data;
    }


    public void TakeDamage(float dmg)
    {
        health.TakeDamage(dmg);

        bool isDead = health.IsDead();

        if (isDead)
        {
            if (gameObject != null)
            {
                Destroy(gameObject);
                spawner.spawnUnit();
            }

        }
    }

    public void HandleDeath()
    {
        isDead = true;
    }
}
