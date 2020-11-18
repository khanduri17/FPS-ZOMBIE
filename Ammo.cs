using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
  
   [SerializeField] AmmoSlot[] ammoSlots; 
    
   [System.Serializable]
    private class AmmoSlot
    {
        
        public AmmmoType ammmoType ;
        
        public int ammoAmmount;
       
   
    }

    
    public int Currentammo(AmmmoType ammmoType )
    {
        return getAmmoslot(ammmoType).ammoAmmount;
    }

    public void reduceAmmo(AmmmoType ammmoType)
    {
         getAmmoslot(ammmoType).ammoAmmount--;
    }
    public void increaseAmmo(AmmmoType ammmoType,int ammoAmmount)
    {
        getAmmoslot(ammmoType).ammoAmmount = getAmmoslot(ammmoType).ammoAmmount+ammoAmmount;
        
    }
    private AmmoSlot getAmmoslot(AmmmoType ammoType)
    {

        foreach(AmmoSlot slot in ammoSlots)
        {
            if (ammoType == slot.ammmoType)
            {
                return slot;
            }
        }
        return null;

    }

}
