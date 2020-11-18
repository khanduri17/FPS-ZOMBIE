using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int ammoAmmount = 5;
    [SerializeField] AmmmoType ammmoType;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            FindObjectOfType<Ammo>().increaseAmmo(ammmoType, ammoAmmount);
            Destroy(gameObject);
        }
       
    }
}

