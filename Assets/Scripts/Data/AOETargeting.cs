using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AOETargeting : MonoBehaviour
{
    public PlayerInputHandler input;
    public GameObject attackPrefab;
    void Update()
    {
        if(input != null)
        {
            if(input.MouseRayCastHitInfo.collider.CompareTag("Player") || input.MouseRayCastHitInfo.collider.CompareTag("Enemy"))
            {
                transform.position = input.MouseRayCastHitInfo.collider.gameObject.transform.position;
            }
            else
            {
                transform.position = input.MouseRayCastHitInfo.point;

            }
        }
    }
    public void Cast()
    {
        Instantiate(attackPrefab, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
