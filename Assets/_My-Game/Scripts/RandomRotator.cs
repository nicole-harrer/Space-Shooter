using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotator : MonoBehaviour {

    public float tumble;
    private Rigidbody rb;

	void Start()
	{
       
        rb = GetComponent<Rigidbody>();
        //random is a class that will provide a random value betwee 0 and 1
        //angular velocity = how fast rigidbody object is rotating
        //tumble speed set in the inspector in unity
        rb.angularVelocity = Random.insideUnitSphere * tumble;
	}
}
