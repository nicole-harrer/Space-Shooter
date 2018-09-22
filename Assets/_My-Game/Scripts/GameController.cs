using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//have to add this to make the text type work-why? I have not a clue
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public GameObject hazard;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float waveWait;
    public float startWait;

    public Text scoreText;
    private int score;

    //the start functon calls the spawn waves function
	private void Start()
	{
        score = 0;
        UpdateScore();
        //start coroutine is necessary
        StartCoroutine (SpawnWaves());

	}
    //this function needs to be called when the script compiles, so it's called in the start function
	IEnumerator SpawnWaves ()
    {
        yield return new WaitForSeconds(startWait);
        //parameters in a function are separated by commas, but in a for loop they are statements separted by ;
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {

                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
        }
    }

    public void AddScore (int newScoreValue)
    {
        score = score + newScoreValue;
        UpdateScore();

    }


    // this function sets the score to the new score and displays as Score: X
    void UpdateScore ()
    {
        scoreText.text = "Score: " + score;

    }

}


