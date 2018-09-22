using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mover : MonoBehaviour {

    public float speed;
    private Rigidbody rb;
    //we want it to move automatically when entering the scene, lazerbolt needs own velocity thru rb
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;
    }

		
	}
