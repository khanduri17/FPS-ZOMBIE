using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    PlayerHealth target;
    [SerializeField] float Damage = 40f;
    
    void Start()
    {
        target = FindObjectOfType<PlayerHealth>();
    }

    public void EnemyHitEvent()
    { 
        
        if (target == null) { return; }
      
        target.DecreaseHealth(Damage);
        target.GetComponent<DamageRecieved>().showDamage();
        
    }

}
