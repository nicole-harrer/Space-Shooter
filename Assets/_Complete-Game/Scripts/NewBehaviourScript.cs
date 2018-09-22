using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {


    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    //called before every physics step
    private void FixedUpdate()
    {
        //this grabs the input from the player the axees are default

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        //vector3 (x,y,z)
        // y = up and down-it doesn't need to move this way
        //left and right= move horizontal = x value
        //forward and back = move vertical = z value

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.velocity = movement;
    }
	

}
