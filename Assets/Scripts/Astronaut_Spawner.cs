using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Astronaut_Spawner : MonoBehaviour
{
    public GameObject Astronaut;
    public BoxCollider2D SpawnArea;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("AstronautSpawners");
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().isGameOver)
        {
            StopCoroutine("AstronautSpawners");
        }
    }

    public void AstronautSpawer()
    {
        Bounds bounds = SpawnArea.bounds;

        float randomX = Random.Range(bounds.min.x, bounds.max.x);
        float randomY = Random.Range(bounds.min.y, bounds.max.y);

        Vector3 spawnarea = new Vector3(randomX, randomY);
        Instantiate(Astronaut,spawnarea,Quaternion.identity);
    }

    IEnumerator AstronautSpawners()
    {
        while (true)
        {
           AstronautSpawer();
           yield return new WaitForSeconds(7);
        }
    }
}
