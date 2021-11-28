using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    [SerializeField] List<Enemy> spawns = new List<Enemy>();
    [SerializeField] int maxSpawned, spawned;
    bool unlimited;
    public bool spawning = true;
    public float delay = 2;

    IEnumerator Spawning()
    {
        while(spawning)
        {
            if(spawned <= maxSpawned)
            {
                if(!unlimited)
                {
                    Destroy(gameObject);
                }

            }
            else
            {
                Enemy newEnemy = Instantiate(GetRandomEnemy(), transform.position, transform.rotation);
                newEnemy.HealthCPNT.OnDeath.AddListener(EnemyDeath);
            }
            yield return new WaitForSeconds(delay);
        }
        yield return null;
    }
    void EnemyDeath()
    {
        spawned--;
    }
    Enemy GetRandomEnemy()
    {
        if(spawns.Count > 0)
        {
            return spawns[Random.Range(0, spawns.Count)];
        }
        else
        {
            return null;
        }
        
    }

}

