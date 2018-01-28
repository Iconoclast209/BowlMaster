using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject ball;

    private Vector3 offset;
    private Camera camera;

	// Use this for initialization
	void Start () {
        camera = GetComponent<Camera>();
        camera.transform.position = new Vector3(0, 50, -50);
        offset = new Vector3(0, 50, -50);
	}
	
	// Update is called once per frame
	void Update () {
        if(camera.transform.position.z < 1789)
        {
            camera.transform.position = ball.transform.position + offset;
        }
        //Otherwise the Camera will stop moving near headpin
        
	}
}
