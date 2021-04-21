using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathHandler : MonoBehaviour
{

    [SerializeField] Canvas gameOver;
    void Start()
    {
        gameOver.enabled = false;
    }

    public void HandleDeath()
    {
        gameOver.enabled = true;
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        FindObjectOfType<WeaponSwitcher>().enabled = false;
        FindObjectOfType<Weapon>().enabled = false;
    }

   
}
