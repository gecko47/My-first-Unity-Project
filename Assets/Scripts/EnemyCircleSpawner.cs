using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCircleSpawner : MonoBehaviour
{
    public GameObject circleEnemy;
    public GameObject target;
    public float circleSpeed;
    public int numberOfCircleEnemiesToSpawn;

    public void Start()
    {
        // spawn a new circle at a random position, makes the circle a child of the spawner
        for (int i = 0; i < numberOfCircleEnemiesToSpawn; i++)
        {
            // Vector3 randomPosition = new Vector3(Random.Range(-5, 5), Random.Range(-5, 5));
            Instantiate(circleEnemy, this.transform.position, Quaternion.identity, transform);
        }        
    }
}
