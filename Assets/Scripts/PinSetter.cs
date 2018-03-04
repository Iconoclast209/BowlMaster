using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour {

    public Text pinStandingCountText;
    public bool ballEnteredBox = false;
    public int lastStandingCount=-1;
    public float distanceToRaise = 40f;

    private Ball ball;
    private CameraController mainCamera;
    private Animator animator;
    private Pin[] pinArray;
    private float lastChangeTime;
    
    private void Start()
    {
        CountStanding();
        ball = FindObjectOfType<Ball>();
        mainCamera = FindObjectOfType<CameraController>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if(ballEnteredBox)
        {
            CheckStanding();
        }
    }

    void CheckStanding()
    {
        int currentStanding = CountStanding();

        if(currentStanding != lastStandingCount)
        {
            lastChangeTime = Time.time;
            lastStandingCount = currentStanding;
            return;
        }

        float settleTime = 3.0f;
        if((Time.time - lastChangeTime) > settleTime)
        {
            PinsHaveSettled();
        }
            
    }
    
    void PinsHaveSettled()
    {
        print("Pins Have Settled.");
        pinStandingCountText.color = Color.green;
        ballEnteredBox = false;
        lastStandingCount = -1;
        ball.Reset();
        mainCamera.Reset();
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
            }
        }
        pinStandingCountText.text = pinsStanding.ToString();
        return pinsStanding;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Ball>())
        {
            pinStandingCountText.color = Color.red;
            ballEnteredBox = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<Ball>())
        {
            CountStanding();
            Invoke("CountStanding", 2f);
            return;
        }

        Pin pinToDestroy = other.gameObject.GetComponentInParent<Pin>();
        GameObject obj = pinToDestroy.gameObject;
        if (pinToDestroy != null)
        {
            print(obj.name + " has left the pinsetter area");
            Destroy(obj);
        }
    }

    public void ResetPins()
    {
        animator.SetTrigger("resetTrigger");
    }

    public void TidyUpPins()
    {
        animator.SetTrigger("tidyTrigger");
    }

    public void RaisePins()
    {
        pinArray = FindObjectsOfType<Pin>();

        foreach (Pin p in pinArray)
        {
            if (p.IsStanding())
            {
                Rigidbody rb = p.GetComponent<Rigidbody>();
                rb.useGravity = false;
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
                float newXPos = p.transform.position.x;
                float newYPos = p.transform.position.y + distanceToRaise;
                float newZPos = p.transform.position.z;
                p.transform.position = new Vector3(newXPos, newYPos, newZPos);
            }
        }
    }

    public void LowerPins()
    {
        pinArray = FindObjectsOfType<Pin>();

        foreach (Pin p in pinArray)
        {
            if (p.IsStanding())
            {
                Rigidbody rb = p.GetComponent<Rigidbody>();
                float newXPos = p.transform.position.x;
                float newYPos = p.transform.position.y - distanceToRaise;
                float newZPos = p.transform.position.z;
                p.transform.position = new Vector3(newXPos, newYPos, newZPos);
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
                rb.useGravity = true;
            }
        }
        
    }

    public void RenewPins()
    {
        print("Renewing Pins.");
    }
}
