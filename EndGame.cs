using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    [SerializeField] Canvas gameover;
    private void OnTriggerEnter(Collider other)
    {
        gameover.enabled = true;
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        FindObjectOfType<WeaponSwitcher>().enabled = false;
        FindObjectOfType<Weapon>().enabled = false;
    }
}
