using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyManager : MonoBehaviour
{
    #region Singleton
    public static EnemyManager Instance { get { return instance; } }
    static EnemyManager instance;
    #endregion

    public List<Enemy> Enemies { get { return enemies; } }
    List<Enemy> enemies;

    public UnityEvent<Enemy> OnEnemyDeath;
    public UnityEvent<Enemy> OnEnemyCreate;

    private void Awake()
    {
        instance = this;
        enemies = new List<Enemy>();
        OnEnemyCreate.AddListener(OnEnemySpawn);
        OnEnemyDeath.AddListener(OnEnemyDead);
    }


    public void OnEnemySpawn(Enemy spawned)
    {
        enemies.Add(spawned);
    }
    public void OnEnemyDead(Enemy dead)
    {
        enemies.Remove(dead);
    }




}
