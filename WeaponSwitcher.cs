using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    [SerializeField] int currentWeaponIndex=0;
    void Start()
    {
        setWeaponActive();
    }
    void Update()
    {
        int previousWeaponIndex = currentWeaponIndex;
        processKeyInput();
        processsMouseScroll();
        

        if (previousWeaponIndex != currentWeaponIndex)
        {
            setWeaponActive();
        }

    }

    private void processsMouseScroll()
    {
       if(Input.GetAxis("Mouse ScrollWheel")<0)
        {
            
            if (currentWeaponIndex >= transform.childCount-1 )
            {
                currentWeaponIndex = 0;
            }
            else
            {
                currentWeaponIndex++;
            }
           
        }
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {

            if (currentWeaponIndex <= 0)
            {
                currentWeaponIndex = transform.childCount - 1;
            }
            else
            {
                currentWeaponIndex--;
            }

        }
    }

    void processKeyInput()
    {

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentWeaponIndex = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentWeaponIndex = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            currentWeaponIndex = 2;
        }
    }

    private void setWeaponActive()
    {
        int weaponIndex=0;

        foreach(Transform weapon in transform)
        {
            if (weaponIndex == currentWeaponIndex)
            {
                weapon.gameObject.SetActive(true);
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }

            weaponIndex++;
        }
    }

  
}
