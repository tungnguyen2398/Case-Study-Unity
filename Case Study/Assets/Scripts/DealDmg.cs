using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDmg : MonoBehaviour
{
    public float Dmg;
    private bool isCollied = false;
    /*public void SetDamage(float dmg)
    {
        this.Dmg = dmg;
    }*/


    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            isCollied = !isCollied;
        Debug.Log("start collied");

        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            isCollied = !isCollied;
            Debug.Log("exit collied");

        }
    }
    public bool ColliedStatus()
    {
        return isCollied;
    }
    private void OnTriggerStay(Collider collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Enemy enemy = collision.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(this.Dmg);
            }
        }
    }
}
