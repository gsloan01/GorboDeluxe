using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class EnemyDetection : MonoBehaviour
{
    Enemy thisEnemy;
    public List<Player> inRange;
    public bool removeOutOfRange = true;

    private void Awake()
    {
        thisEnemy = GetComponentInParent<Enemy>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Player p = other.GetComponent<Player>();
            thisEnemy.OnFindNewPlayer(p);
            inRange.Add(p);
        }
    }

    private void OnTriggerExit(Collider other)
    {

        if(removeOutOfRange && other.CompareTag("Player"))
        {
            inRange.Remove(other.GetComponent<Player>());
        }
    }
}