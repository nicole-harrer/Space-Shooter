using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;

}

//This class is inheriting from MonoBehavior class
public class RaptorController : MonoBehaviour {

    public float speed = 10;
    public Boundary boundary;
    private Rigidbody rb;
    private AudioSource sound;
    public float tilt;


    public GameObject shot;
    public Transform shotOrigin;
    public float fireRate;

    private float nextFire;


    void Start (){
       rb = GetComponent <Rigidbody>();
       sound = GetComponent<AudioSource>();

    }
	
    void Update()
	{

        if (Input.GetButton("Fire1") && Time.time > nextFire){
             
            nextFire = Time.time + fireRate;
            //GameObject clone =
            Instantiate(shot, shotOrigin.position, shotOrigin.rotation);
            //as GameObject;
            //Play is called to play the clip associated
            sound.Play();

        } 
        //Cmd + ' with "Instantiate" selected
        //Instantiate(object, position, rotation); the object is the shot, the position and rotation are in the ojects transform. Quaternium is the rotation
             //If left like this without an event listener, a stream of shots will be made:
        //Instantiate(shot, shotOrigin.position, shotOrigin.rotation);
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

        Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * speed);

        rb.position = new Vector3
            (
            //Mathf, to explore meanings Cmd + '
            //easy to use math functions-we want a function called clamp. this will clamp any given value between and min and a max
                Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
            //y value = up and down, set to 0 because you don't want the ship to leave the plane

                0.0f,
               
                Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
        );

         rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * -tilt);
	}
}
