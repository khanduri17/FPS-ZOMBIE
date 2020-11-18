using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField]Transform target;
    [SerializeField] float chasingRange=5f;
    NavMeshAgent navmeshagent;
    float distanceToTarget=Mathf.Infinity;
    bool isProvoked=false;
    float turnspeed = 1f;
    EnemyHealth enemyHealth;

    void Start()
    {
        enemyHealth = GetComponent<EnemyHealth>();
        navmeshagent = GetComponent<NavMeshAgent>();
    }


    void Update()
    {
        if (enemyHealth.isDied())
        {
            enabled = false;
            navmeshagent.enabled = false;
        }

        distanceToTarget = Vector3.Distance(target.position, transform.position);

        if (isProvoked)
        {
            EngageTarget();
        }
        else if (distanceToTarget<=chasingRange)
        {
            isProvoked = true;
            
        }
        
    }
    void EngageTarget()
    {
        FaceTarget();
        if (distanceToTarget>=navmeshagent.stoppingDistance)
        {
            chaseTarget();
        }  
        if (distanceToTarget <= navmeshagent.stoppingDistance)
        {
            attackTarget();
        } 
    }
    public void OnDamageTaken()
    {
        isProvoked = true;
    } 
    void chaseTarget()
    {
        
        GetComponent<Animator>().SetBool("Attack", false);
        GetComponent<Animator>().SetTrigger("move");
        if (navmeshagent.enabled == true)
        {
            navmeshagent.SetDestination(target.position);
        }
        }  
    void attackTarget()
    {
          GetComponent<Animator>().SetBool("Attack", true);

    }
    private void FaceTarget()
    {
        Vector3 Direction = (target.position - transform.position).normalized;
        Quaternion LookRotation = Quaternion.LookRotation(new Vector3(Direction.x, 0, Direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, LookRotation, Time.deltaTime * turnspeed);
    } 
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chasingRange);
    }
}
