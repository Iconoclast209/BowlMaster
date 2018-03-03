using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    public float launchVelocity = 3f;
    public bool isInMotion = false;
    public Vector3 ballSpawnPosition;
    private Rigidbody rig;
    private AudioSource audioSource;

    // Use this for initialization
	void Start ()
    {
        rig = GetComponent<Rigidbody>();
        rig.useGravity = false;
        audioSource = GetComponent<AudioSource>();
    }

    public void Launch(Vector3 velocity)
    {
        isInMotion = true;
        rig.useGravity = true;
        rig.velocity = velocity;
        audioSource.Play();
    }

    public void Reset()
    {
        print("Reset Ball.");
        isInMotion = false;
        rig.velocity = Vector3.zero;
        rig.angularVelocity = Vector3.zero;
        rig.rotation = Quaternion.identity;
        rig.useGravity = false;
        transform.position = ballSpawnPosition;
        
    }
}
