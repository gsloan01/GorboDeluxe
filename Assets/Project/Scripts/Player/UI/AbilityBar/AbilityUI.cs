using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class AbilityUI : MonoBehaviour
{
    [SerializeField] PlayerCombatController thisPlayer;
    PlayerAbility ability;
    [SerializeField] int index;
    [SerializeField] Image icon, cooldownImage;

    private void OnEnable()
    {
        ability = thisPlayer.abilities[index];
        icon.sprite = ability.icon;
    }

    private void Update()
    {
        cooldownImage.fillAmount = ability.cooldownTimer / ability.cooldown;
    }
}

