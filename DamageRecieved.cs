
using System;
using System.Collections;
using UnityEngine;

public class DamageRecieved : MonoBehaviour
{
    [SerializeField] Canvas impactCanvas;
    float impactTime = 0.3f;



    void Start()
    {
        impactCanvas.enabled = false;
    }

    
    void Update()
    {
            
    }
    
   public void showDamage()
    {
        StartCoroutine(showSplatter());
    }

    IEnumerator showSplatter()
    {
        impactCanvas.enabled = true;

        yield return new WaitForSeconds(impactTime);
        impactCanvas.enabled = false;

    }
}

