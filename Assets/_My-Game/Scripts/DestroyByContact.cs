using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {


    public GameObject explosion;
    public GameObject playerExplosion;
    //private AudioSource sound_one;
    //private AudioSource sound_two;
    public int scoreValue;

    //you have to create an instance of the class so when an asteroid is destroyed it will add to the score
    private GameController gameController;




    private void Start()
	{
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }

        if (gameController == null){
            Debug.Log("Cannot find 'GameController' script");
        }
	}


    void OnTriggerEnter(Collider other)
	{
        Debug.Log(other.name);
        //Debug.Log(other.name);
        if (other.tag =="Boundary")
        {
            return;
        }
        //sound_one.Play();
        if (other.tag == "Player")
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            // sound_two.Play();
        }

        gameController.AddScore(scoreValue);
        Destroy(other.gameObject);
        Instantiate(explosion, transform.position, transform.rotation);
        Destroy(gameObject);
	}
}
