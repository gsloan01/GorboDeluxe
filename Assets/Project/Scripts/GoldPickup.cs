using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldPickup : MonoBehaviour
{
    [SerializeField] int value = 1;
    [SerializeField] AudioSource audioSource;
    bool collected;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && other.TryGetComponent<Player>(out Player thisPlayer) && !collected)
        {
            collected = true;
            thisPlayer.data.OnGoldChange(value);
            audioSource?.Play();
            Destroy(gameObject, audioSource.clip.length);
        }
    }
}
