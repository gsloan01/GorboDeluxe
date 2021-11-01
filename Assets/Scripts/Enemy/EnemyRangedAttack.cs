using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]
public class EnemyRangedAttack : MonoBehaviour
{
    [SerializeField] bool collideWithAll;
    [SerializeField] float lifetimeAfterCollide = 0;
    [SerializeField] float lerpSmoothing = 1.0f;
    

    Rigidbody rb;
    public GameObject target;
    public Transform targetingTransform;
    [SerializeField] projectileType type;

    bool collided;

    enum projectileType
    {
        Forces, Lerp
    }

    //ctor
    EnemyRangedAttack(GameObject target)
    {
        this.target = target;
    }

    private void Awake()
    {
        //grab the component
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        switch (type)
        {
            case projectileType.Forces:
                rb.AddForce(Vector3.Normalize(target.transform.position - transform.position));
                break;
            case projectileType.Lerp:
                transform.position = Vector3.Lerp(transform.position, targetingTransform.position, lerpSmoothing * Time.deltaTime);
                break;
            default:
                break;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if(collideWithAll)
        {
            OnCollide();
        }
        else
        if (!other.CompareTag("Enemy"))
        {
            if (other.CompareTag("Player"))
            {
                //deal damage to the player
                //do fx
                Debug.Log("Projectile has collided with a player");
                OnCollide();
            }
        }
        
    }

    void OnCollide()
    {
        //Spawn cool FX
        Destroy(gameObject, lifetimeAfterCollide);
    }
}
