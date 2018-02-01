using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Ball))]
public class DragLaunch : MonoBehaviour {

    public float xMax;
    private bool ballIsInMotion = false;
    private Ball ball;
    private float startPosX;
    private float startPosY;
    private float startTime;

	// Use this for initialization
	void Start () {
        ball = GetComponent<Ball>();	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void DragStart()
    {
        // Capture time and position of click/finger
        if(! ball.isInMotion)
        {
            startTime = Time.time;
            startPosX = Input.mousePosition.x;
            startPosY = Input.mousePosition.y;
        }
        
    }

    public void DragEnd()
    {
        if (! ball.isInMotion)
        {        
        float swipeSpeed = Time.time - startTime;
        float differenceInPosX = Input.mousePosition.x - startPosX;
        float differenceInPosY = Input.mousePosition.y - startPosY;
        Vector3 launchVelocity = new Vector3(differenceInPosX, 0, differenceInPosY/swipeSpeed);
        ball.Launch(launchVelocity);
        ballIsInMotion = true;
        }
    }

    public void MoveStart(float xNudge)
    {
        if(! ball.isInMotion)
        {
            float currentXPosition = ball.transform.position.x;
            ball.transform.position = new Vector3(Mathf.Clamp(currentXPosition + xNudge, -xMax,xMax), 13, 15);
        }
    }
}
