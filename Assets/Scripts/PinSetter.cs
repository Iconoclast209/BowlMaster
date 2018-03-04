using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour {

    public Text pinStandingCountText;
    public bool ballEnteredBox = false;
    public int lastStandingCount=-1;
    public GameObject pinSetPrefab;
    public Vector3 pinSetSpawnPosition;

    private Ball ball;
    private CameraController mainCameraController;
    private Animator animator;
    private Pin[] pinArray;
    private float lastChangeTime;
    
    private void Start()
    {
        CountStandingAndUpdateDisplay();
        ball = FindObjectOfType<Ball>();
        mainCameraController = FindObjectOfType<CameraController>();
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
        int currentStanding = CountStandingAndUpdateDisplay();

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
        mainCameraController.Reset();
    }

    public int CountStandingAndUpdateDisplay()
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
            CountStandingAndUpdateDisplay();
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
            p.Raise();
        }
    }

    public void LowerPins()
    {
        pinArray = FindObjectsOfType<Pin>();

        foreach (Pin p in pinArray)
        {
            p.Lower();
        }
    }

    public void RenewPins()
    {
        Instantiate(pinSetPrefab, pinSetSpawnPosition, Quaternion.identity);
    }
}
