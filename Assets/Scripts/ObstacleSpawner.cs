using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstacle1, obstacle2, obstacle3, obstacle4, obstacle5;
    [HideInInspector] public float obstacleSpawnInterval = 2.5f;
 


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("SpawnObstacles");
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().isGameOver)
        {

            StopCoroutine("SpawnObstacles");

        
        }    
    }

    private void SpawnObstacle()
    {
        int random = Random.Range(1, 6);
        float obstacleY = 0.5f;

        if(random == 1)
        {
            Instantiate(obstacle1, new Vector3(transform.position.x, obstacleY, 0), Quaternion.identity);
        } 
        else if (random == 2)
        { 
            Instantiate(obstacle2, new Vector3(transform.position.x, obstacleY, 0), Quaternion.identity);
        }
         else if (random == 3)
        {
            Instantiate(obstacle3, new Vector3(transform.position.x, obstacleY, 0), Quaternion.identity);
        }
        else if (random == 4)
        {
            Instantiate(obstacle4, new Vector3(transform.position.x, obstacleY + 1.0f, 0), Quaternion.identity);
        }
        else if (random == 5)
        {
            Instantiate(obstacle5, new Vector3(transform.position.x, obstacleY + 1.5f, 0), Quaternion.identity);
        }


    }    


  

    IEnumerator SpawnObstacles()
    {
        while (true)
        {
            SpawnObstacle();
            yield return new WaitForSeconds(obstacleSpawnInterval);
        }    

    }    

}
