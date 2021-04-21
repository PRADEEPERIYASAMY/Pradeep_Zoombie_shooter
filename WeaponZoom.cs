using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] Camera fpsCamera;
    [SerializeField] float zoomoutfov = 50f;
    [SerializeField] float zoominfov = 35f;

    bool Zoomedintoogle = false;
    [SerializeField] float zoomoutsensitivity = 2f;
    [SerializeField] float zoominsensitivity = .5f;
    [SerializeField]RigidbodyFirstPersonController firstPersonController;




    // Update is called once per frame
    private void OnDisable()
    {
        ZoomOut();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (Zoomedintoogle == false)
            {
                ZoomIn();

            }
            else
            {
                ZoomOut();

            }
        }

        }

    private void ZoomOut()
    {
        Zoomedintoogle = false;
        fpsCamera.fieldOfView = zoomoutfov;
        firstPersonController.mouseLook.XSensitivity = zoomoutsensitivity;
        firstPersonController.mouseLook.YSensitivity = zoomoutsensitivity;
    }

    private void ZoomIn()
    {
        Zoomedintoogle = true;
        fpsCamera.fieldOfView = zoominfov;
        firstPersonController.mouseLook.XSensitivity = zoominsensitivity;
        firstPersonController.mouseLook.YSensitivity = zoominsensitivity;
    }

}

