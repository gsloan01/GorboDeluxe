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
    [SerializeField] float projectileSpeed = 1.0f;

    Rigidbody rb;
    public GameObject target;
    public Transform targetingTransform;
    [SerializeField] AttackData data;
    [SerializeField] projectileType type;

    bool collided;

    enum projectileType
    {
        TransformMove, Lerp
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
            case projectileType.TransformMove:
                Vector3.MoveTowards(transform.position, targetingTransform.transform.position, Time.deltaTime * projectileSpeed);
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
        if (!other.CompareTag("Enemy"))
        {
            if (other.CompareTag("Player"))
            {
                //deal damage to the player
                //do fx
                other.GetComponent<Health>().Apply(data);
                //Debug.Log("Projectile has collided with a player");
                OnCollide();
            }
            if (collideWithAll)
            {
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
