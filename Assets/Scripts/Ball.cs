using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    public float launchVelocity = 3f;
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
        rig.useGravity = true;
        rig.velocity = velocity;
        audioSource.Play();
    }

    // Update is called once per frame
    void Update () {
		
	}
}
