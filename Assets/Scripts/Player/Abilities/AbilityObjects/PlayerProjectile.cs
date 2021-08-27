using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    public GameObject CreateFX;
    public GameObject DestroyOnEnemyFX;
    public AttackData attackData;
    public Rigidbody rb;
    public bool isHoming;
    public float homeAfterTime;
    public bool isPiercing;
    public bool destroyAfterMany;
    public int destroyAfterAmount;
    public bool doesSplashDamage;
    public float splashRange;

    public float flySpeed = 5.0f;

    private void Start()
    {
        if (CreateFX != null) Instantiate(CreateFX, transform.position, Quaternion.LookRotation(transform.forward, Vector3.up), null);

        //Set Velocity to a semi-high value to shoot forward
        rb.velocity = transform.forward * flySpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            if(doesSplashDamage)
            {
                if (DestroyOnEnemyFX != null) Instantiate(DestroyOnEnemyFX, transform.position + Vector3.up * .01f, Quaternion.LookRotation(transform.forward, Vector3.up), null);
                List<Damageable> enemies = EnemyManager.Instance.GetEnemyDamageablesInRangeOf(transform.position, splashRange);
                foreach(Damageable e in enemies)
                {
                    e.RecieveDamage(attackData.damages, gameObject);
                }
            }
            else
            {
                if(DestroyOnEnemyFX != null) Instantiate(DestroyOnEnemyFX, other.transform.position + Vector3.up * .2f, Quaternion.LookRotation(transform.forward, Vector3.up), other.transform);
                other.GetComponent<Damageable>().RecieveDamage(attackData.damages, gameObject);
            }

            Destroy(gameObject);
        }
        else
        {
            if(!other.CompareTag("Player"))
            {
                Destroy(gameObject);
            }
        }
    }

}
