using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float PlayerHealthPoints =200f;
    
    public void DecreaseHealth(float Damage)
    {
        PlayerHealthPoints = PlayerHealthPoints - Damage;
        if (PlayerHealthPoints <= 0)
        {
            GetComponent<DeathHandler>().HandleDeath();
        }
    }
}
