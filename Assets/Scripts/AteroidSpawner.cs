using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AteroidSpawner : MonoBehaviour
{
    public GameObject Asteroid;
    public BoxCollider2D SpawnArea;
    
    
    public float SpawnInterval = 2f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("AsteroidSpawns");
        StartCoroutine("AsteroidTimeIcreases");
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().isGameOver)
        {
            StopCoroutine("AsteroidSpawns");
            StopCoroutine("AsteroidTimeIcreases");
        }
    }

    public void AsteroidSpawn()
    {
        Bounds bounds = SpawnArea.bounds;
        
        float randomX = Random.Range(bounds.min.x, bounds.max.x);
        float randomY = Random.Range(bounds.min.y, bounds.max.y);

        Vector3 spawnPosition = new Vector3(randomX, randomY);
        Instantiate(Asteroid, spawnPosition, Quaternion.identity);
        
    }

    IEnumerator AsteroidSpawns()
    {
        while (true)
        {
            AsteroidSpawn();
            yield return new WaitForSeconds(SpawnInterval);
        }
    }

    IEnumerator AsteroidTimeIcreases()
    {
        while (true)
        {
            yield return new WaitForSeconds(10);
            if (SpawnInterval > 0.5)
            {
                SpawnInterval -= 0.1f;
            }
        }
    }
}
