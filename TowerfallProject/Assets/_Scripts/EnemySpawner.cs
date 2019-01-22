using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public int ObsToPlace = 10;
    public GameObject[] Obstacles = new GameObject[0];
    GameObject Obstacle;

    public float obstacleCheckRadius = 3f;
    public int maxSpawnAttemptsPerObstacle = 10;

    public float timer;

    private void Update()
    {
        timer += Time.deltaTime;
        if(timer > 3)
        {
            Spawn();
            timer = 0;
        }
    }

    void Spawn()
    {

        for (int i = 0; i < ObsToPlace; i++)
        {
            Obstacle = Obstacles[Random.Range(0, Obstacles.Length)];

            // Create a position variable
            Vector3 position = Vector3.zero;

            // whether or not we can spawn in this position
            bool validPosition = false;

            // How many times we've attempted to spawn this obstacle
            int spawnAttempts = 0;

            // While we don't have a valid position 
            //  and we haven't tried spawning this obstable too many times
            while (!validPosition && spawnAttempts < maxSpawnAttemptsPerObstacle)
            {
                // Increase our spawn attempts
                spawnAttempts++;

                // Pick a random position
                position = new Vector3(Random.Range(15,20f), transform.position.y, 0);

                // This position is valid until proven invalid
                validPosition = true;

                // Collect all colliders within our Obstacle Check Radius
                Collider[] colliders = Physics.OverlapSphere(position, obstacleCheckRadius);

                // Go through each collider collected
                foreach (Collider col in colliders)
                {
                    // If this collider is tagged "Obstacle"
                    if (col.tag == "Obstacle")
                    {
                        // Then this position is not a valid spawn position
                        validPosition = false;
                    }
                }
            }

            // If we exited the loop with a valid position
            if (validPosition)
            {
                // Spawn the obstacle here
                Instantiate(Obstacle, position + Obstacle.transform.position, Quaternion.identity);
            }
        }
    }
}
