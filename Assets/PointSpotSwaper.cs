using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointSpotSwaper : MonoBehaviour
{
    public float initialDelayLimitLower = 1f;
    public float initialDelayLimitUpper = 5f;
    public SpotScript leftSpotScript;
    public SpotScript rightSpotScript;
    // Start is called before the first frame update
    void Start()
    {
        if (Random.value < 0.5f)
        {
            leftSpotScript.SwitchedOn = true;
            rightSpotScript.SwitchedOn = false;
            
            // Debug.Log("lt on");
        }
        else{
            leftSpotScript.SwitchedOn = false;
            rightSpotScript.SwitchedOn = true;

            // Debug.Log("rt on");
        }

        float initialDelay = Random.Range(initialDelayLimitLower, initialDelayLimitUpper);
        Invoke("SpotSwap", initialDelay);
    }

    void SpotSwap()
    {
        leftSpotScript.SwitchedOn = !leftSpotScript.SwitchedOn;
        rightSpotScript.SwitchedOn = !rightSpotScript.SwitchedOn;
        // Debug.Log("Swapped"); 

        float newDelay = Random.Range(initialDelayLimitLower, initialDelayLimitUpper);
        
        Invoke("SpotSwap", newDelay);
    }
}
