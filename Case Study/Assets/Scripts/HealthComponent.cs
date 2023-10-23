using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    public float Hp;
    public float maxHp;
    public HealthUI healthUI;
    public void SetHp(float hp)
    {
        this.maxHp = hp;
        this.Hp = hp;
    }

    public void TakeDamage(float dmg)
    {
        this.Hp -= dmg;
        if(this.Hp <= 0)
        {
            this.Hp = 0;
            IsDead();
            return;
        }
        float percent = Hp / maxHp;
        healthUI.UpdateHealthBar(percent);
    }


    public bool IsDead()
    {
        return Hp <= 0;
    }

}
