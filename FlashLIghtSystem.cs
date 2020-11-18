
using System;
using UnityEngine;

public class FlashLIghtSystem : MonoBehaviour
{

    [SerializeField] float lightDecay = 0.1f;
    [SerializeField] float angleDecay =0.001f;
    [SerializeField] float minimumAngle = 40f;
    Light myLight;
    void Start()
    {
        myLight = GetComponent<Light>(); 
    }

    // Update is called once per frame
    void Update()
    {
        DecreaseLightAngle();
        DecreaseIntensity();
    }

    public void RestoreLightAngle(float restoreAngle)
    {

        myLight.spotAngle = restoreAngle;

    }
    public void RestoreLightIntensity(float restoreIntensity)
    {
        myLight.intensity += restoreIntensity;
    }
    



    private void DecreaseIntensity()
    {
        myLight.intensity -= lightDecay * Time.deltaTime;
    }

    private void DecreaseLightAngle()
    {
        if (myLight.spotAngle <= minimumAngle)
        {
            return;
        }
        else
        {
            myLight.spotAngle -= angleDecay * Time.deltaTime;
        }

    }
}
