using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CustomRPSlider : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] Image fill;
    [SerializeField] TMP_Text amount;

    private void Start()
    {
        OnResourceUpdated(50);
        player.OnPlayerResourceChange.AddListener(OnResourceUpdated);

    }
    void OnResourceUpdated(float change)
    {
        amount.text = Mathf.Round(player.AbilityResource).ToString();
        fill.fillAmount = player.AbilityResource / player.AbilityResourceMax;

    }
}
