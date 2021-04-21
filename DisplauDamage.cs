using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class DisplauDamage : MonoBehaviour
{
    [SerializeField] Canvas impCanvas;
    [SerializeField] float impactTime = 0.3f;
    [SerializeField] AudioSource zombieatack;
    // Start is called before the first frame update
    void Start()
    {
        impCanvas.enabled = false;
    }

    public void ShowDamageImpact()
    {
        StartCoroutine(showSplatter());
    }

    IEnumerator showSplatter()
    {
        zombieatack.Play();
        impCanvas.enabled = true;
        yield return new WaitForSeconds(impactTime);
        impCanvas.enabled = false;
        zombieatack.Stop();
    }
}
