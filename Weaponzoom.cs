using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Weaponzoom : MonoBehaviour
{
    [SerializeField] Camera fpsCamera;
    [SerializeField] RigidbodyFirstPersonController player;
    [SerializeField] float zoomedOutFOV = 60f;
    [SerializeField] float zoomedInFOV = 30f;
    bool zoomedInToggle=false;
    [SerializeField] float zoomOutSensitivity = 2.5f;
    [SerializeField] float zoomInSensitivity = 0.8f;


    private void Start()
    {
       
    }
    private void OnDisable()
    {
        zoomOut();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (zoomedInToggle == false)
            {
                zoomIn();

            }
            else
            {
                zoomOut();
            }

        }
        
    }

    private void zoomOut()
    {
        fpsCamera.fieldOfView = zoomedOutFOV;
        zoomedInToggle = false;
        player.mouseLook.XSensitivity = zoomOutSensitivity;
        player.mouseLook.YSensitivity = zoomOutSensitivity;
    }

    private void zoomIn()
    {
        fpsCamera.fieldOfView = zoomedInFOV;
        zoomedInToggle = true;
        player.mouseLook.XSensitivity = zoomInSensitivity;
        player.mouseLook.YSensitivity = zoomInSensitivity;
    }
}
