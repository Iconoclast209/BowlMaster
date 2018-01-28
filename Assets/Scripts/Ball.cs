using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    public float initialVelocity = 3f;
    private Rigidbody rig;
    private AudioSource audioSource;

    // Use this for initialization
	void Start ()
    {
        rig = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();

        Launch();
    }

    public void Launch()
    {
        rig.velocity = new Vector3(0, 0, initialVelocity);
        audioSource.Play();
    }

    // Update is called once per frame
    void Update () {
		
	}
}
