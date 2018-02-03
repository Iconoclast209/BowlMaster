using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour {

    public Text pinStandingCountText; 
    private Pin[] pinArray;
    

    private void Start()
    {
        
        CountStanding();
    }


    public int CountStanding()
    {
        int pinsStanding = 0;
        pinArray = FindObjectsOfType<Pin>();

        foreach (Pin p in pinArray)
        {
            if (p.IsStanding())
            {
                pinsStanding++;
                print(p.name + " is standing.");
            }
        }
        pinStandingCountText.text = pinsStanding.ToString();
        return pinsStanding;
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.GetComponent<Ball>())
        {
            CountStanding();
            Invoke("CountStanding", 2f);
        }
    }

}
