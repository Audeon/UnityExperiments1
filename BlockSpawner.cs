using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;

public class BlockSpawner : MonoBehaviour
{
    public GameObject fallingRock;
    public Vector2 secondsBetweenSpawnTimeMinMax;
    public Vector2 spawnSizeMinMax;
    public float spawnAngleMax;
    
    private GameObject attackRock;
    private float nextSpawnTime;
    private Vector2 screenHalfWidthInWorldUnits;
    
    // Old method of changing difficulty.
    // public float difficultyChangeRateInSeconds = 2;
    // public Vector2 difficultyStepInSecondsAndSpeedUnits = new Vector2(.025f, 1);
    // private float nextDifficultyChange; 
    
    // Start is called before the first frame updategmail.com
    void Start()
    {
        screenHalfWidthInWorldUnits = new Vector2(Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize);
    }

    // Update is called once per frame
    void Update()
    {
        // New Method of making difficulty uses the difficultyManager class and does a LERP (Linear Interpolation) calculation on the min and max values and the percent of current difficulty to move between. 
        float secondsBetweenSpawnTime = Mathf.Lerp(secondsBetweenSpawnTimeMinMax.y, secondsBetweenSpawnTimeMinMax.x,
            DifficultyManager.GetDifficultyPercent());
        if (Time.time > nextSpawnTime)
        {
            // print($"Seconds Between Spawn Time: {secondsBetweenSpawnTime}");
            // print($"Current Difficulty: { DifficultyManager.GetDifficultyPercent()}");
            nextSpawnTime = Time.time + secondsBetweenSpawnTime;
            MakeRock();
        }

        // This was my old method of dealing with difficulting. The solution i came up with before watching tut. 
        // It changes the spawn rate of the rocks based on a change in difficulty that happens at the interval set.
        // if (secondsBetweenSpawnTime >= minSecondsBetweenSpawn)
        // {
        //     if (Time.time > nextDifficultyChange)
        //     {
        //
        //         nextDifficultyChange = Time.time + difficultyChangeRateInSeconds;
        //         print($"Next Difficulty Change: {nextDifficultyChange}");
        //         secondsBetweenSpawnTime = secondsBetweenSpawnTime - 0.025f;
        //         print($"secondsBetweenSpawnTime: {secondsBetweenSpawnTime}");
        //     }
        // }
    }
    

    private void MakeRock()
    {
        float spawnSize = Random.Range(spawnSizeMinMax.x, spawnSizeMinMax.y);
        float spawnAngle = Random.Range(-spawnAngleMax, spawnAngleMax);
        Vector2 randomSpawn = new Vector2(Random.Range(-screenHalfWidthInWorldUnits.x, screenHalfWidthInWorldUnits.x),
            transform.position.y);
        Vector3 randomSpawnRot = new Vector3(0, Random.Range(0, 360), 0);
        attackRock = (GameObject) Instantiate(fallingRock, randomSpawn, Quaternion.Euler(Vector3.forward * spawnAngle));
        attackRock.tag = "rock";
        attackRock.transform.parent = transform;
        attackRock.transform.localScale = Vector3.one * spawnSize;
        

    }
            
    
}
