using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject ball;
    public Vector3 cameraSpawnPosition = new Vector3(0, 50, -50);
    public Vector3 offset = new Vector3(0, 50, -50);

    private Camera camera;


    void Start()
    {
        camera = GetComponent<Camera>();
        camera.transform.position = cameraSpawnPosition + offset;
    }
	
	// Update is called once per frame
	void Update () {
        if(camera.transform.position.z < 1789)
        {
            camera.transform.position = ball.transform.position + offset;
        }
        //Otherwise the Camera will stop moving near headpin  
	}

    public void Reset()
    {
        camera.transform.position = cameraSpawnPosition + offset;
    }
}
