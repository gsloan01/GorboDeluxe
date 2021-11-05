using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemInfoDisplay : MonoBehaviour
{
    public ItemData data;
    public TMP_Text txt;
    public GameObject visuals;

    private void Update()
    {

        transform.position = PlayerManager.Instance.player.GetComponent<Player>().inputHandler.MousePos;

    }

    public void PopUp(ItemData newItem)
    {
        txt.text = newItem.name;
        visuals.SetActive(true);
    }
    public void GoAway()
    {
        visuals.SetActive(false);
    }
}
