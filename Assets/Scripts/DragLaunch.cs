using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Ball))]
public class DragLaunch : MonoBehaviour {
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
        startTime = Time.time;
        startPosX = Input.mousePosition.x;
        startPosY = Input.mousePosition.y;
    }

    public void DragEnd()
    {
        float swipeSpeed = Time.time - startTime;
        Debug.Log("Swipe Speed:  " + swipeSpeed.ToString());
        float differenceInPosX = Input.mousePosition.x - startPosX;
        float differenceInPosY = Input.mousePosition.y - startPosY;
        Debug.Log(differenceInPosX + ", " + differenceInPosY);

        Vector3 launchVelocity = new Vector3(differenceInPosX, 0, differenceInPosY/swipeSpeed);
        ball.Launch(launchVelocity);
              
    }
}
