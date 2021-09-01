using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public bool spawnManyAtATime;
    public bool spawnUnlimited;
    public int howManyAtATime;
    public List<GameObject> spawnableEnemies;
    public float timeBetween = 3.5f;

    public bool active;

    float timer;
    List<GameObject> spawned;

    private void Update()
    {
        if(active)
        {
            timer += Time.deltaTime;

            if(spawnManyAtATime)
            {
                if(timer >= timeBetween && spawned.Count < howManyAtATime)
                {
                    SpawnNewEnemy();
                }
            }
            else if(spawnUnlimited)
            {
                if(timer >= timeBetween)
                {
                    SpawnNewEnemy();
                }
            }
        }

    }

    void SpawnNewEnemy()
    {
        if(spawnableEnemies.Count > 0)
        {
            
            if(spawnableEnemies.Count == 1)
            {
                Spawn(spawnableEnemies[0]);
            }
            else
            {
                int enemyIndex = Random.Range(0, spawnableEnemies.Count - 1);
                Spawn(spawnableEnemies[enemyIndex]);
            }

            timer = 0;
        }
        else
        {
            Debug.Log($"{name} cannot spawn an enemy, as there are no enemies in the list!");
        }
    }

    void Spawn(GameObject newEnemy)
    {
        spawned.Add(Instantiate(newEnemy, transform.position, transform.rotation, null));
    }
}
