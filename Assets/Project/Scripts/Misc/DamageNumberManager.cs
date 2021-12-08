using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageNumberManager : MonoBehaviour
{
    public static DamageNumberManager Instance { get; private set; }
    public DamageNumber defaultPrefab, critPrefab;
    public AudioClip critSFX;

    private void Awake()
    {
        Instance = this;
    }

    public void SpawnNumber(int number, bool crit, Transform spawn)
    {
        DamageNumber damageNum = crit ? Instantiate(critPrefab, spawn) : Instantiate(defaultPrefab, spawn);
        damageNum.Set(Mathf.Abs(number), crit);
        Destroy(damageNum.gameObject, 1);
        if (critSFX != null) SFXManager.Instance?.PlaySFX(critSFX, spawn, false);
    }
}
