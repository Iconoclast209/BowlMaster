using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour
{

    [Tooltip("The amount in degrees that the pin can be off of the X and Z axes and still be considered standing upright")]
    public float standingThreshold = 5f;
    public float distanceToRaise = 40f;

    private void Start()
    {
        IsStanding();
    }

    public bool IsStanding()
    {
        Vector3 rotationInEuler = transform.rotation.eulerAngles;

        float xTilt = Mathf.Abs(rotationInEuler.x);
        float zTilt = Mathf.Abs(rotationInEuler.z);
                
        if (xTilt < standingThreshold || xTilt > (360 - standingThreshold))
        {
            if (zTilt < standingThreshold || zTilt > (360 - standingThreshold))
            {
                return true;
            }
        }
      
        return false;
    }

    public void Raise()
    {
        if(IsStanding())
        {
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.useGravity = false;
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            float newXPos = transform.position.x;
            float newYPos = transform.position.y + distanceToRaise;
            float newZPos = transform.position.z;
            transform.position = new Vector3(newXPos, newYPos, newZPos);
        }
    }

    public void Lower()
    {
        if (IsStanding())
        {
            Rigidbody rb = GetComponent<Rigidbody>();
            float newXPos = transform.position.x;
            float newYPos = transform.position.y - distanceToRaise;
            float newZPos = transform.position.z;
            transform.position = new Vector3(newXPos, newYPos, newZPos);
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            rb.useGravity = true;
        }
        
    }

}
