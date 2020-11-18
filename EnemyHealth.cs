﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float hitPoints=50f;
    bool isDead = false;

    public bool isDied()
    {
        return isDead;
    }


    public void TakeDamage(float Damage)
    {
        BroadcastMessage("OnDamageTaken");
        hitPoints = hitPoints - Damage;
        if (hitPoints <= 0)
        {
            Die();
        }
    }
    private void Die()
    {
        if (isDead) { return; }
        isDead = true;
        GetComponent<Animator>().SetTrigger("die");
    }



}
