using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery : MonoBehaviour
{
    [SerializeField] FlashLIghtSystem flashLight;
    [SerializeField] float restoreAngle = 88f;
    [SerializeField] float restoreIntensity = 7;



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            
            flashLight.RestoreLightAngle(restoreAngle);
            flashLight.RestoreLightIntensity(restoreIntensity);
            Destroy(gameObject);
        }
    }
}
