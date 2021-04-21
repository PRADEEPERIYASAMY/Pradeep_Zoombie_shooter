using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryPickups : MonoBehaviour
{
    [SerializeField] float restoreAngle = 90f;
    [SerializeField] float restoreIntensity = 10f;
    [SerializeField] AudioSource pickups;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            pickups.Play();
            other.GetComponentInChildren<FlashLight>().RestoreAngle(restoreAngle);
            other.GetComponentInChildren<FlashLight>().RestoreLight(restoreIntensity);
            Destroy(gameObject);
        }
    }
}
