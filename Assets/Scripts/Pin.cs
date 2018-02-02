using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour {

    [Tooltip("The amount in degrees that the pin can be off of the X and Z axes and still be considered standing upright")]
    public float standingThreshold = 5f;

    private void Start()
    {
        IsStanding();
    }

    private void Update()
    {

    }

    public bool IsStanding()
    {
        Vector3 rotationInEuler = transform.rotation.eulerAngles;

        float xTilt = Mathf.Abs(rotationInEuler.x);
        float zTilt = Mathf.Abs(rotationInEuler.z);
        print(this.name +" "+ xTilt + ", " + zTilt);
        
        if (xTilt < standingThreshold || xTilt > (360 - standingThreshold))
        {
            if (zTilt < standingThreshold || zTilt > (360 - standingThreshold))
            {
                print("true");
                return true;

            }
        }
        print("false");
        return false;
        
    }
}
