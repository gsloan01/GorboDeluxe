using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemInfoDisplay : MonoBehaviour
{
    public ItemData data;
    public TMP_Text txt;

    private void Update()
    {
        if(gameObject.activeInHierarchy)
        {
            transform.position = PlayerManager.Instance.player.GetComponent<Player>().inputHandler.MousePos;
        }
    }
}
