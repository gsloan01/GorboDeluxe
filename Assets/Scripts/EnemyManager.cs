using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager Instance { get { return instance; } }
    static EnemyManager instance;
    public List<Enemy> Enemies { get { return enemies; } }
    List<Enemy> enemies;



    private void Awake()
    {
        instance = this;
        enemies = new List<Enemy>();
    }


    public void OnEnemySpawn(Enemy spawned)
    {
        enemies.Add(spawned);
    }
    public void OnEnemyDeath(Enemy dead)
    {
        enemies.Remove(dead);
    }

    /// <summary>
    /// Gets the nearest enemy to a certain point within a certain distance. Returns null if no enemies are found
    /// </summary>
    /// <param name="transform"></param>
    /// <returns></returns>
    public Enemy GetNearestTo(Transform from, float maxDistance)
    {
        Enemy found = null;
        float shortest = float.MaxValue;
        if (enemies.Count == 0) return found;
        foreach(Enemy enemy in enemies)
        {

            float distance = Vector3.Distance(from.position, enemy.transform.position);
            if (found == null)
            {
                found = enemy;
                shortest = distance;
            }

            if (distance <= maxDistance)
            {
                if(distance < shortest)
                {
                    found = enemy;
                    shortest = distance;
                }
            }
        }
        return found;
    }
    public List<Enemy> GetEnemiesInRangeOf(Vector3 from, float range)
    {
        if (Enemies.Count == 0) return null;
        List<Enemy> enemies = new List<Enemy>();
        foreach(Enemy e in Enemies)
        {
            float dist = Vector3.Distance(from , e.transform.position);
            if(dist <= range)
            {
                enemies.Add(e);
            }
        }
        return enemies;
    }
    public List<Damageable> GetEnemyDamageablesInRangeOf(Vector3 from, float range)
    {
        if (Enemies.Count == 0) return null;
        List<Damageable> enemyDamageables = new List<Damageable>();
        foreach (Enemy e in Enemies)
        {
            float dist = Vector3.Distance(from, e.transform.position);
            if (dist <= range)
            {
                enemyDamageables.Add(e.GetComponent<Damageable>());
            }
        }
        return enemyDamageables;
    }
}
